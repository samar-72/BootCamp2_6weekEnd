using BootCamp2_6weekEnd.Models;

namespace BootCamp2_6weekEnd.Repository.Base
{
    public interface IUnitOfWork
    {

        IRepoEmployee Employees { get; }
        IRepoProduct Products { get; }

        IRepository<Category> Categories { get; }
        IRepository<Supplier> Suppliers { get; }
        IRepository<Order> Orders { get; }
        IRepository<Customer> Customers { get; }
        IRepository<OrderItem> OrderItems { get; }
           

        void Save();
    }
}
