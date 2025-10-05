 using BootCamp2_6weekEnd.Data;
using BootCamp2_6weekEnd.Filters;
using BootCamp2_6weekEnd.Models;
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BootCamp2_6weekEnd.Controllers
{
    [SessionAuthourize]
    public class CategoriesController : Controller
    {
        private readonly AppDBContext _dbContext; // inject the database context

        public CategoriesController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Categories
        public IActionResult Index()
        {
            IEnumerable<Category> categories = _dbContext.Categories.ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult GetAllCategories()
        {
            IEnumerable<Category> categories = _dbContext.Categories.ToList();
            return Ok(categories);
        }
        //***********************************************************//
        // GET: Categories/Create
        public IActionResult Create()                                                     
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public IActionResult Create (Category category)
        {
            if (string.IsNullOrEmpty(category.Description))
            {
                ModelState.AddModelError("Customer", "now you need Desc.");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["Add"] = "Category has been added Successfully";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["Error"] = "Please Enter All Data";
                return View(category);
            }
         
        }

        //***********************************************************//
        // GET: Categories/Edit
        public IActionResult Edit(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Categories/Edit
        [HttpPost]

        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Update(category);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        //***********************************************************//
        // GET: Categories/Delete
        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST: Categories/DeleteConfirmed
        [HttpPost, ActionName("DeleteConfirmed")]

        public IActionResult DeleteConfirmed(int id)
        {
            var category = _dbContext.Categories.Find(id);
            if (category == null)
                return NotFound();

            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
