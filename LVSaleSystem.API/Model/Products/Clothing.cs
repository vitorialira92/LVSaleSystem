using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVSaleSystem.API.Model.Products
{
    public class Clothing : IProduct
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
        public ClothingType Type { get; set; }
        [Required]
        public string PictureFileName { get; set; }

        public Clothing() { }

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
