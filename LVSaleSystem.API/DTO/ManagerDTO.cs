using LVSaleSystem.API.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO
{
    public class ManagerDTO
    {
        [Required]
        public int Id {  get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
