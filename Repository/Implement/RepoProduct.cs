using BootCamp2_6weekEnd.Models;
using BootCamp2_6weekEnd.Repository.Base;
using BootCamp2_6weekEnd.Data;
using Microsoft.EntityFrameworkCore;

namespace BootCamp2_6weekEnd.Repository.Implement
{
    public class RepoProduct : IRepoProduct
    {
        private readonly AppDBContext _context;
        public RepoProduct(AppDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {

            return _context.Products.Include(p => p.Category);
        }

        IEnumerable<Product> IRepoProduct.GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
