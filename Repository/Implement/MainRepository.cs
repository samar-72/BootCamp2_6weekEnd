using BootCamp2_6weekEnd.Models;
using BootCamp2_6weekEnd.Repository.Implement;
using BootCamp2_6weekEnd.Data;
using System;
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
            _context.SaveChanges();
        }

        public void Delete(X entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<X> GetAll()
        {
            throw new NotImplementedException();
        }

        public X GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(X entity)
        {
            throw new NotImplementedException();
        }
    }
}
