using LVSaleSystem.API.Data;
using LVSaleSystem.API.Model.Users;

namespace LVSaleSystem.API.Repositories
{
    public class ManagerRepository : IRepository<Manager>
    {
        private readonly LVContext _context;
        public ManagerRepository(LVContext context)
        {
            _context = context;
        }

        public Manager Add(Manager entity)
        {
            _context.Managers.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(Manager entity)
        {
            throw new NotImplementedException();
        }

        public Manager GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Manager GetByUsername(string username)
        {
            return _context.Managers.FirstOrDefault(x => x.UserDetails.UserName == username);
        }
    }
}
