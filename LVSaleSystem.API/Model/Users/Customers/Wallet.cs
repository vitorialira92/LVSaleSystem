using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVSaleSystem.API.Model.Users.Customers
{
    public class Wallet
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Balance { get; set; }
        public virtual CreditCard? CreditCard { get; set; }

        
    }
}
