using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeaklyTypedLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPost(string username, string password)
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            return View();
        }

        public IActionResult StronglyTypedView()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginSuccess(LoginViewModel login)
        {
            if(login.Username !=null && login.Password!=null)
            {
                if(login.Username.Equals("admin") && login.Password.Equals("admin"))
                {
                    ViewBag.Message = "You are successfully logged in admin";
                    return View();
                }
            }
            ViewBag.Message = "Invalid Credentials";
            return View();
        }

        public IActionResult UserDetails()
        {
            var user = new LoginViewModel()
            {
                Username = "Batool",
                Password = "123"
            };
            return View(user);
        }
        public IActionResult UserList()
        {
            var users = new List<LoginViewModel>()
            {
                new LoginViewModel() {Username = "Batool", Password = "123"},
                new LoginViewModel() {Username = "Ali", Password = "456"},
                new LoginViewModel() {Username = "Ziad", Password = "789"},
            };
            return View(users);
        }

        public IActionResult GetAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            if(ModelState.IsValid)
            {
                return View("Success");
            }
            return View("GetAccount");
        }
    }
}
