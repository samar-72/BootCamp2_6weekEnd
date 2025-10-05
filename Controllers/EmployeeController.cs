using BootCamp2_6weekEnd.Data;
using BootCamp2_6weekEnd.Filters;
using BootCamp2_6weekEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6weekEnd.Controllers
{
    [SessionAuthourize]
    public class EmployeesController : Controller
    {
        private readonly AppDBContext _context;
        public EmployeesController(AppDBContext context)
        {
            _context = context;
        }
        // GET: Employees
        public IActionResult Index()
        {
            IEnumerable<Employee> Employees = _context.Employees.ToList();
            return View(Employees);
        }
        // GET: Employees
        [HttpGet]
        public IActionResult GetAllEmp(int? id)
        {
            IEnumerable<Employee> Employees = _context.Employees.ToList();
            return View(Employees);
        }
        //***********************************************************//
        // GET: Employees/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        //***********************************************************//
        // GET: Employees/Edit
        public IActionResult Edit(int id)
        {

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        //***********************************************************//
        // GET: Employees/Delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        [HttpPost]
        [HttpPost, ActionName("DeleteConfirmed")]

        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}