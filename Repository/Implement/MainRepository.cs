using BootCamp2_6weekEnd.Data;
using BootCamp2_6weekEnd.Repository.Base;
namespace BootCamp2_6weekEnd.Repository.Implement
{
    public class MainRepository<X> : IRepository<X> where X : class
    {
        private readonly AppDBContext _context;
        public MainRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Create(X entity)
        {
            _context.Set<X>().Add(entity);
        }

        public void Update(X entity)
        {
            _context.Set<X>().Update(entity);
        }

        public void Delete(X entity)
        {
            _context.Set<X>().Remove(entity);
        }

        public X GetById(int Id)
        {
            return _context.Set<X>().Find(Id);
        }

        public IEnumerable<X> GetAll()
        {
            return _context.Set<X>().ToList();
        }



    }
}