using BootCamp2_6weekEnd.Data;
using BootCamp2_6weekEnd.Filters;
using BootCamp2_6weekEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BootCamp2_6weekEnd.Controllers
{
    [SessionAuthourize]
    public class ProductsController : Controller
    {
        private readonly AppDBContext _context;
     

        public ProductsController(AppDBContext context)
        {
            _context = context;
        }
        // GET: Products
        public IActionResult Index()
        {
            IEnumerable<Product> Products = _context.Products.ToList();
            return View(Products);
        }
        // GET: Products
        [HttpGet]
        public IActionResult GetAllEmp(int? id)
        {
            IEnumerable<Product> Products = _context.Products.ToList();
            return View(Products);
        }
        //***********************************************************//
        // GET: Products/Create
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.CategoryId =_context.Categories.ToList();
            IEnumerable<Category> categories = _context.Categories.ToList();

            SelectList selectListItems = new SelectList(categories, "Id", "Name", 0);
            ViewBag.Categories = selectListItems;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product Product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(Product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }
        //***********************************************************//
        // GET: Products/Edit
        public IActionResult Edit(int id)
        {

            var Product = _context.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }
        [HttpPost]
        public IActionResult Edit(Product Product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(Product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(Product);
        }
        //***********************************************************//
        // GET: Products/Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            return View(Product);
        }
        [HttpPost]
        [HttpPost, ActionName("DeleteConfirmed")]

        public IActionResult DeleteConfirmed(int id)
        {
            var Product = _context.Products.Find(id);
            if (Product == null)
                return NotFound();

            _context.Products.Remove(Product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}