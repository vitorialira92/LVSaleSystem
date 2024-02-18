using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Model.Products
{
    public class Accessory : IProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }
        [Required]
        public AccessoryType Type { get; set; }

        public bool UpdateDescription(string newDescription)
        {
            if (newDescription == null) return false;

            Description = newDescription;
            return true;
        }

        public bool UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0) return false;

            Price = newPrice;
            return true;
        }
    }
}
