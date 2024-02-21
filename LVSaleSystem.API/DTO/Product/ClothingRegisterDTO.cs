using LVSaleSystem.API.Model.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO.Product
{
    public class ClothingRegisterDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Type { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
