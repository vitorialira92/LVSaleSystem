namespace LVSaleSystem.API.Repositories
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        T Add(T entity);
        void Delete(T entity);
    }
}
