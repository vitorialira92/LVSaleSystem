using LVSaleSystem.API.AccessTokens;
using LVSaleSystem.API.DTO.Login;
using LVSaleSystem.API.Exceptions;
using LVSaleSystem.API.Model.Users.Customers;
using LVSaleSystem.API.Repositories;
using LVSaleSystem.API.Util;

namespace LVSaleSystem.API.Services
{
    public class LoginService
    {
        public CustomerRepository _customerRepository;
        public ManagerRepository _managerRepository;
        public TokenService _tokenService;

        public LoginService(CustomerRepository customerRepository, 
            ManagerRepository managerRepository, TokenService tokenService)
        {
            _customerRepository = customerRepository;
            _managerRepository = managerRepository;
            _tokenService = tokenService;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var manager = _managerRepository.GetByUsername(request.Username);
            var customer = _customerRepository.GetByUsername(request.Username);

            if(manager == null && customer == null)
            {
                throw new ResourceNotFoundException("Usuário", 404);
            }



            int userRole; 
            string token;
            int userId;

            if(manager == null)
            {
                if (!HashUtil.VerifyInput(request.Password, customer.UserDetails.HashedPassword,
                        customer.UserDetails.Salt)){
                    throw new LoginException();
                }
                userRole = 2;
                userId = customer.Id;
                token = _tokenService.GenerateToken(userId, Model.Users.UserRole.Customer);
            }
            else
            {
                if (!HashUtil.VerifyInput(request.Password, manager.UserDetails.HashedPassword,
                        manager.UserDetails.Salt))
                {
                    throw new LoginException();
                }
                userRole = 1;
                userId = manager.Id;
                token = _tokenService.GenerateToken(userId, Model.Users.UserRole.Admin);
            }

            return new LoginResponse
            {
                Token = token,
                UserId = userId,
                UserRole = userRole
            };
        }
    }
}
