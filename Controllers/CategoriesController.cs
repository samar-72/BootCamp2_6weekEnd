using BootCamp2_6weekEnd.Interfaces;
using BootCamp2_6weekEnd.Models;
using BootCamp2_6weekEnd.Repository.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BootCamp2_6weekEnd.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Categories
        public IActionResult Index()
        {
            var categories = _unitOfWork.Categories.GetAll();
            return View(categories);
        }

        // GET: Categories/Details/5
        public IActionResult Details(int? id)
        {
            var category = _unitOfWork.Categories.GetById(id.Value);
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,uId,Name,Description")] Category category)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Categories.Create(category);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitOfWork.Categories.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,uId,Name,Description")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Categories.Update(category);
                    _unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    var exists = _unitOfWork.Categories.GetById(category.Id);
                    if (exists == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }

                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _unitOfWork.Categories.GetById(id.Value);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _unitOfWork.Categories.GetById(id);
            if (category != null)
            {
                _unitOfWork.Categories.Delete(category);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
