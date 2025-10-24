using BootCamp2_6weekEnd.Data;
using BootCamp2_6weekEnd.Repository.Base;
using BootCamp2_6weekEnd.Models;

namespace BootCamp2_6weekEnd.Repository.Implement
{
    public class RepoEmployee : MainRepository<Employee>,  IRepoEmployee
    {
        private readonly AppDBContext _context;
        public RepoEmployee(AppDBContext context): base(context)
        {
            _context = context;
        }
      public  Employee Login(string userName, string password)
        {
            return _context.Employees.FirstOrDefault(e => e.UserName == userName && e.Password == password);
        }

       
    }
}
