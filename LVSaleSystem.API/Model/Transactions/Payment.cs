using LVSaleSystem.API.Model.Users.Customers;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Model.Transactions
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public virtual CreditCard CreditCard { get; set; }
    }
}
