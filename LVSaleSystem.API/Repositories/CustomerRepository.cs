using LVSaleSystem.API.Data;
using LVSaleSystem.API.Exceptions;
using LVSaleSystem.API.Model.Users;
using LVSaleSystem.API.Model.Users.Customers;
using Microsoft.EntityFrameworkCore;

namespace LVSaleSystem.API.Repositories
{
    public class CustomerRepository : IRepository<Customer>
    {
        private readonly LVContext _context;
        public CustomerRepository(LVContext context)
        {
            _context = context;
        }

        public Customer Add(Customer entity)
        {
            _context.Customers.Add(entity); 
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
           var customer = _context.Customers.FirstOrDefault(x => x.Id == id);

            if (customer == null)
                throw new ResourceNotFoundException("Cliente", 404);

            return customer;
        }

        internal Customer GetByUsername(string username)
        {
            return _context.Customers.FirstOrDefault(x => x.UserDetails.UserName == username);
        }

        internal CreditCard GetCreditCardByCustomerId(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);

            if (customer == null)
                throw new ResourceNotFoundException("Client", 404);

            var card = customer.Wallet.CreditCard;

            if (card == null)
                throw new ResourceNotFoundException("Credit card", 404);


            return card;
        }

        internal decimal GetTotalInWallet(int customerId)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);

            if (customer == null)
                throw new ResourceNotFoundException("Client", 404);

            return customer.Wallet.Balance;
        }

        internal void UseWalletAmout(int customerId, decimal discount)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);

            if (customer == null)
                throw new ResourceNotFoundException("Client", 404);

            var balance = customer.Wallet.Balance;

            if (discount > balance)
                throw new BadHttpRequestException("Balance unavailable for this transaction");

            balance -= discount;
            customer.Wallet.Balance = balance;

            _context.Wallets.Update(customer.Wallet);
            _context.SaveChanges();

        }
        
        internal void AddToWalletAmout(int customerId, decimal amount)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == customerId);

            if (customer == null)
                throw new ResourceNotFoundException("Client", 404);

            var balance = customer.Wallet.Balance;

            balance += amount;
            customer.Wallet.Balance = balance;

            _context.Wallets.Update(customer.Wallet);
            _context.SaveChanges();

        }
    }
}
