using System.ComponentModel.DataAnnotations;

namespace LVSaleSystem.API.Model.Products
{
    public interface IProduct
    {
        public int Id { get; set; }
        public string PictureFileName { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool UpdateDescription(string newDescription);
        public bool UpdatePrice(decimal newPrice);
    }
}
