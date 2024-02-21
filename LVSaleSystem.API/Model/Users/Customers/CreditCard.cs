using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Model.Users.Customers
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [CreditCard]
        public string Number { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
        [Required]
        public string CVV { get; set; }

    }
}
