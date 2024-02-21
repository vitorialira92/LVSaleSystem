using LVSaleSystem.API.Data;
using LVSaleSystem.API.Model.Products;
using LVSaleSystem.API.Model.Stocks;
using LVSaleSystem.API.Model.Transactions;

namespace LVSaleSystem.API.Repositories
{
    public class ProductsRepository : IRepository<Clothing>
    {
        private readonly LVContext _context;

        public ProductsRepository(LVContext context)
        {
            _context = context;
        }

        public Clothing Add(Clothing entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Clothing entity)
        {
            throw new NotImplementedException();
        }

        public Clothing GetById(int id)
        {
            return _context.Clothings.FirstOrDefault(x => x.Id == id);
        }
        public ClothingStock GetStockByProductId(int id)
        {
            return _context.ClothingStocks.FirstOrDefault(x => x.Item.Id == id);
        }

        public bool AlterStock(int id, int quantity)
        {
            var stock = GetStockByProductId(id);

            bool ok;

            if (quantity > 0)
                ok = stock.AddStock(quantity);
            else 
                ok = stock.RemoveStock(quantity);
            
            if(!ok)
                return false;

            _context.Update(stock);
            _context.SaveChanges();
            return true;
        }
    }
}
