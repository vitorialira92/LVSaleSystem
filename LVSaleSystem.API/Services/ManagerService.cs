using LVSaleSystem.API.DTO;
using LVSaleSystem.API.Model.Users;
using LVSaleSystem.API.Repositories;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Services
{
    public class ManagerService
    {
        public ManagerRepository _repository;

        public ManagerService(ManagerRepository repository)
        {
            _repository = repository;
        }
        internal ManagerDTO AddManager(ManagerRegisterDTO managerDTO)
        {
            Manager manager = new Manager
            {
                Name = managerDTO.Name,
                Email = managerDTO.Email,
                UserDetails = new UserDetails(managerDTO.Username, 
                    managerDTO.Password, UserRole.Admin)
            };
            var man = _repository.Add(manager);

            return new ManagerDTO
            {
                Id = man.Id,
                Name = man.Name,
                Email = man.Email,
                Username = man.UserDetails.UserName
            };
        }
    }
}
