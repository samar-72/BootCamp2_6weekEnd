using BootCamp2_6weekEnd.Models;
namespace BootCamp2_6weekEnd.Repository.Base
{
    public interface IRepoEmployee
    {
        Employee Login(string UserName, string Password);


    }
}
