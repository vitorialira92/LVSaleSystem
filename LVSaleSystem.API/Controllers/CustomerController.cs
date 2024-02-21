using LVSaleSystem.API.DTO;
using LVSaleSystem.API.Model.Users.Customers;
using LVSaleSystem.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace LVSaleSystem.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController
    {
        private readonly CustomerService _customerService;
        public CustomerController(CustomerService service)
        {
            _customerService = service;
        }
        [HttpPost]
        public CustomerDTO AddCustomer([FromBody] CustomerRegisterDTO customerDTO)
        {
            return _customerService.AddCustomer(customerDTO);
        }
    }
}
