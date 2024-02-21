using LVSaleSystem.API.Data;
using LVSaleSystem.API.Model.Transactions;

namespace LVSaleSystem.API.Repositories
{
    public class SellingRepository : IRepository<Selling>
    {
        private readonly LVContext _context;

        public SellingRepository(LVContext context)
        {
            _context = context;
        }
        public Selling Add(Selling entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Selling entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public Selling GetById(int id)
        {
            return _context.Sellings.FirstOrDefault(x => x.Id == id);
        }

        internal List<Selling> GetAll()
        {
            return _context.Sellings.ToList();
        }
    }
}
