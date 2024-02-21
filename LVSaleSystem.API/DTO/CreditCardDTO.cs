using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO
{
    public class CreditCardDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [CreditCard]
        public string Number { get; set; }
        [Required]
        public string ExpirationDate { get; set; }
    }
}
