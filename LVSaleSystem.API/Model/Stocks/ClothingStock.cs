using LVSaleSystem.API.Model.Products;
using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Model.Stocks
{
    public class ClothingStock : IStock<Clothing>
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual Clothing Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool AddStock(int quantity)
        {
            if (quantity < 0) return false;

            this.Quantity += quantity;
            return true;
        }

        public bool RemoveStock(int quantity)
        {
            if (quantity < 0 || quantity > this.Quantity) return false;

            this.Quantity -= quantity;
            return true;
        }
    }
}
