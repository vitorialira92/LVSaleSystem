using LVSaleSystem.API.Controllers;
using LVSaleSystem.API.DTO.Selling;
using LVSaleSystem.API.Exceptions;
using LVSaleSystem.API.Model.Transactions;
using LVSaleSystem.API.Repositories;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Services
{
    public class SellingService
    {
        private readonly SellingRepository _repository;
        private readonly ProductsRepository _productRepository;
        private readonly CustomerRepository _customerRepository;

        public SellingService(SellingRepository repository, ProductsRepository productRepository,
            CustomerRepository customerRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        internal Selling GetById(int id)
        {
            return _repository.GetById(id);
        }

        internal Selling Add(SellingRegisterDTO sellingDTO)
        {
            var customer = _customerRepository.GetById(sellingDTO.CustomerId);

            if (customer == null)
            {
                throw new ResourceNotFoundException("Client", 404);
            }

            List<SellingItem> items = new List<SellingItem>();


            foreach (var item in sellingDTO.Items)
            {
                items.Add(new SellingItem
                {
                    Product = _productRepository.GetById(item.ItemId),
                    Quantity = item.Quantity,
                    UnityPrice = item.UnityPrice
                });
            }

            if (items.Count == 0)
                throw new BadHttpRequestException("It is not possible to register a sale without items");


            Selling selling = new Selling
            {
                Date = DateTime.UtcNow,
                Items = items,
                Customer = customer
            };

            var amountWallet = _customerRepository.GetTotalInWallet(sellingDTO.CustomerId);

            decimal discount = 0;

            if(amountWallet != 0)
            {
                if(amountWallet > selling.Total)
                {
                    discount = selling.Total;
                }
                else
                    discount = amountWallet;
            }

            _customerRepository.UseWalletAmout(sellingDTO.CustomerId, discount);

            selling.Payment = new Payment
            {
                CreditCard = _customerRepository.GetCreditCardByCustomerId(sellingDTO.CustomerId),
                Discount = discount
            };

            _repository.Add(selling);
            return selling;
        }

        internal List<Selling> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
