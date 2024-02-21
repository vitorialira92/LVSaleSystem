using LVSaleSystem.API.Model.Users.Customers;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO
{
    public class WalletDTO
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Balance { get; set; }
        public CreditCardDTO CreditCard { get; set; }
    }
}
