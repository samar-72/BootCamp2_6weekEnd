

using BootCamp2_6weekEnd.Models;

namespace BootCamp2_6weekEnd.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(int id);

    }
}
