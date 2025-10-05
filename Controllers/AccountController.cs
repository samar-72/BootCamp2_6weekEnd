using BootCamp2_6weekEnd.Filters;
using BootCamp2_6weekEnd.Repository.Base;
using BootCamp2_6weekEnd.Repository.Implement;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6weekEnd.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IRepoEmployee _repoEmployee;
        public AccountsController(IRepoEmployee repoEmployee)
        {
            _repoEmployee = repoEmployee;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {

            var employee = _repoEmployee.Login(UserName, Password);

            HttpContext.Session.SetString("UserName", UserName);
            HttpContext.Session.SetInt32("EmpployeeId", employee.Id);

            return RedirectToAction("Index", "Home");

            if (employee == null)
            {
                ViewBag.Error = "Invalid UserName or Password";
                return View();
            }
        }


            public IActionResult Logout()
            {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        
            }
    }
}