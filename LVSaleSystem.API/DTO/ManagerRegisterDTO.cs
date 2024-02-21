using LVSaleSystem.API.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO
{
    public class ManagerRegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
