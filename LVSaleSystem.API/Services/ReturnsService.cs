
using LVSaleSystem.API.DTO.Returns;
using LVSaleSystem.API.Exceptions;
using LVSaleSystem.API.Model.Transactions;
using LVSaleSystem.API.Repositories;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Services
{
    public class ReturnsService
    {
        private readonly ReturnsRepository _repository;
        private readonly SellingRepository _sellingRepository;
        private readonly CustomerRepository _customerRepository;
        public ReturnsService(ReturnsRepository repository, SellingRepository sellingRepository,
            CustomerRepository customerRepository)
        {
            _repository = repository;
            _sellingRepository = sellingRepository;
            _customerRepository = customerRepository;
        }
        internal List<Return> GetAll()
        {
            return _repository.GetAll();
        }
        public Return Add(ReturnRegisterDTO returnRegisterDTO)
        {
            var selling = _sellingRepository.GetById(returnRegisterDTO.SellingID);

            if (selling == null)
                throw new ResourceNotFoundException("Registro de venda", 400);

            if(selling.Date.AddDays(7) < DateTime.UtcNow)
                throw new BadHttpRequestException("Prazo de devoluções encerrado");

            var item = selling.Items.FirstOrDefault(x => x.Id == returnRegisterDTO.SellingID);

            if (item == null)
                throw new ResourceNotFoundException("Item de venda", 400);

            Return returnEntity = new Return
            {
                Date = DateTime.UtcNow,
                Selling = selling,
                SellingItem = item
            };

            _repository.Add(returnEntity);
            _customerRepository.AddToWalletAmout(returnRegisterDTO.UserId, item.Total);

            return returnEntity;

        }
    }
}
