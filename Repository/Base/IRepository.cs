namespace BootCamp2_6weekEnd.Repository.Implement
{
    public interface IRepository<X> where X : class
    {
        void Create(X entity);
        void Update(X entity);
        void Delete(X entity);
        X GetById(int id);
        IEnumerable<X> GetAll();


    }
}
