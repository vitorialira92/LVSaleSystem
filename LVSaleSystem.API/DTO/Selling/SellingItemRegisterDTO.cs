using LVSaleSystem.API.Model.Products;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.DTO.Selling
{
    public class SellingItemRegisterDTO
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal UnityPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
