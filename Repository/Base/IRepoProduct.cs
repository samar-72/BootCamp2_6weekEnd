using BootCamp2_6weekEnd.Models;

namespace BootCamp2_6weekEnd.Repository.Base
{
    public interface IRepoProduct
    {

        IEnumerable<Product> GetAllProducts();

    }
}
