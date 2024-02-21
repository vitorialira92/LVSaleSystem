using LVSaleSystem.API.Attributes;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Model.Users.Customers
{
    public class Customer : IUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public virtual UserDetails UserDetails { get; set; }
        [Required]
        [CPF(ErrorMessage = "CPF inválido")]
        public string CPF { get; set; }
        [Required]
        public virtual Wallet Wallet { get; set; }
    }
}
