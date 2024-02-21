using LVSaleSystem.API.Attributes;
using LVSaleSystem.API.Model.Users;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO
{
    public class CustomerRegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public UserDetailsDTO UserDetails { get; set; }
        [Required]
        [CPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
