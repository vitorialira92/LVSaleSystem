using LVSaleSystem.API.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO
{
    public class UserDetailsDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
