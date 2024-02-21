using LVSaleSystem.API.Model.Products;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LVSaleSystem.API.Model.Transactions
{
    public class SellingItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Clothing Product { get; set; }
        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal UnityPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        [NotMapped]
        public decimal Total
        {
            get
            {
                return UnityPrice * Quantity;
            }
        }
    }
}
