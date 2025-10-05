using BootCamp2_6weekEnd;
using BootCamp2_6weekEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCamp2_6weekEnd.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }                                                                             

        public virtual DbSet<Category> Categories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

    }
}