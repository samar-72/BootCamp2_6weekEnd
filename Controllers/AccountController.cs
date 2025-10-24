using BootCamp2_6weekEnd.Repository.Base;
using Microsoft.AspNetCore.Mvc;

namespace BootCamp2_6weekEnd.Controllers
{
    public class AccountsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork ;
        public AccountsController(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName, string Password)
        {

            var employee = _unitOfWork.Employees.Login(UserName, Password);


            if (employee == null)
            {
                ViewBag.Error = "Invalid UserName or Password";
                return View();
            }


            HttpContext.Session.SetString("UserName", UserName);
            HttpContext.Session.SetInt32("EmpployeeId", employee.Id);

            return RedirectToAction("Index", "Home");

        }


            public IActionResult Logout()
            {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");

        
            }
    }
}