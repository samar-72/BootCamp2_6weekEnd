using BootCamp2_6weekEnd.Models;
using BootCamp2_6weekEnd.Repository.Implement;
using BootCamp2_6weekEnd.Data;
using BootCamp2_6weekEnd.Repository.Base;

namespace BootCamp2_6weekEnd.Repository.Implement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public UnitOfWork(AppDBContext context)
        {
            _context = context;

            Employees  = new RepoEmployee(_context);
            Products   = new RepoProduct(_context);
            Categories = new MainRepository<Category>(_context);
            Suppliers = new MainRepository<Supplier>(_context);
            Orders = new MainRepository<Order>(_context);
            Customers = new MainRepository<Customer>(_context);
            OrderItems = new MainRepository<OrderItem>(_context);

        }



        public IRepoEmployee Employees { get; }

        public IRepoProduct Products { get; }

        public IRepository<Category> Categories { get; }

        public IRepository<Supplier> Suppliers { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<Customer> Customers { get; }
        public IRepository<OrderItem> OrderItems { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}

