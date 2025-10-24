using BootCamp2_6weekEnd.Interfaces;
using BootCamp2_6weekEnd.Models;
using BootCamp2_6weekEnd.Repository.Base;

namespace BootCamp2_6weekEnd.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void CreateCategory(Category category)
        {
            _unitOfWork.Categories.Create(category);
        }
        public void DeleteCategory(int id)
        {
           var category = _unitOfWork.Categories.GetById(id);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
            }
        }
        public IEnumerable<Category> GetAllCategories()
        {
            return _unitOfWork.Categories.GetAll();
        }
        public Category GetCategoryById(int id)
        {
           return _unitOfWork.Categories.GetById(id);
        }
        public void UpdateCategory(Category category)
        {
            _unitOfWork.Categories.Update(category);
        }

    }
}
