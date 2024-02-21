using LVSaleSystem.API.DTO;
using LVSaleSystem.API.Model.Users;
using LVSaleSystem.API.Model.Users.Customers;
using LVSaleSystem.API.Repositories;

namespace LVSaleSystem.API.Services
{
    public class CustomerService
    {
        public CustomerRepository _repository;

        public CustomerService(CustomerRepository customerRepository)
        {
            _repository = customerRepository;
        }

        public CustomerDTO AddCustomer(CustomerRegisterDTO customerDTO)
        {
            Customer customer = new Customer();

            customer.CPF = customerDTO.CPF;
            customer.Email = customerDTO.Email;
            customer.Name = customerDTO.Name;
           

            Wallet wallet = new Wallet
            {
                Balance = 0
            };
            customer.Wallet = wallet;

            UserDetails userDetails = new UserDetails(
                customerDTO.UserDetails.Username, 
                customerDTO.UserDetails.Password,
                UserRole.Customer);

            customer.UserDetails = userDetails;

            var newCustomer = _repository.Add(customer);

            return new CustomerDTO(newCustomer);

        }
    }
}
