using BootCamp2_6weekEnd.Models;
using BootCamp2_6weekEnd.Repository.Implement;
using BootCamp2_6weekEnd.Data;
using BootCamp2_6weekEnd.Repository.Base;

namespace BootCamp2_6weekEnd.Repository.Implement
{
    public class RepoEmployee : IRepoEmployee
    {
        private readonly AppDBContext context;
        public RepoEmployee(AppDBContext context)
        {
            this.context = context;
        }
        Employee IRepoEmployee.Login(string userName, string password)
        {
            return context.Employees.FirstOrDefault(e => e.UserName == userName && e.Password == password);
        }
    }
}
