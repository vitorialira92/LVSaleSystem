using LVSaleSystem.API.Data;
using LVSaleSystem.API.Model.Transactions;

namespace LVSaleSystem.API.Repositories
{
    public class ReturnsRepository : IRepository<Return>
    {
        private readonly LVContext _context;
        public ReturnsRepository(LVContext context)
        {
            _context = context;
        }
        internal List<Return> GetAll()
        {
            return _context.Returns.ToList();
        }
        
        internal Return Add(Return entity)
        {
            _context.Returns.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Return GetById(int id)
        {
            throw new NotImplementedException();
        }

        Return IRepository<Return>.Add(Return entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Return entity)
        {
            throw new NotImplementedException();
        }
    }
}
