using LVSaleSystem.API.Model.Products;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace LVSaleSystem.API.Model.Stocks
{
    public interface IStock<T> where T : class
    {
        public int Id { get; set; }
        public T Item { get; set; }
        public int Quantity { get; set; }
        public bool AddStock(int quantity);
        public bool RemoveStock(int quantity);

    }
}
