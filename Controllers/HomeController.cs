//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using FirstProject.Models;

//namespace FirstProject.Controllers;

//public class HomeController : Controller
//{
//    private readonly ILogger<HomeController> _logger;

//    public HomeController(ILogger<HomeController> logger)
//    {
//        _logger = logger;
//    }

//    public IActionResult Index()
//    {
//        return View();
//    }

//    public IActionResult Privacy()
//    {
//        return View();
//    }

//    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//    public IActionResult Error()
//    {
//        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//    }
//}
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        public static List<Customer> customers = new List<Customer>()
        {
            new Customer() { Id = 1,Name = "Batool", Amount = 12000},
            new Customer() { Id = 2,Name = "Ali", Amount = 12000}
        };
        public IActionResult Index()
        {
            ViewBag.Message = "Customer Managemnet System";
            ViewBag.CustomerCount = customers.Count();
            ViewBag.CustomerList = customers;
            return View();
        }
        
        //[Route("~/")] ==> this means this is the default route for the application and will over-write the conventional route
        //[Route("/sample/msg")]
        public ViewResult Message() 
        {
            TempData["Message"] = "Customer Managemnet System";
            TempData["CustomerCount"] = customers.Count();
            TempData["CustomerList"] = customers;
            return View();
        }
        public IActionResult Details() 
        {
            ViewData["Message"] = "Customer Managemnet System";
            ViewData["CustomerCount"] = customers.Count();
            ViewData["CustomerList"] = customers;
            return View(); 
        }

        public IActionResult Method1()
        {
            if (TempData["Message"] == null)
            {
                return RedirectToAction("Index");
            }
            //TempData["Message"] = TempData["Message"].ToString();
            return View();
        }

        public IActionResult Login()
        {
            HttpContext.Session.SetString("username", "Batool");

            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            ViewBag.UserName = HttpContext.Session.GetString("username");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToAction("Index");
        }
        //Default Request URL: http://localhost:5000/home/querytest 
        //when I changed the name in the URL: http://localhost:5000/home/querytest?name=Ali%20Assad
        public IActionResult QueryTest()
        {
            string name = "Batool Hammoud";
            if (!String.IsNullOrEmpty(HttpContext.Request.Query["name"]))
            {
                name = HttpContext.Request.Query["name"];
            }
            ViewBag.Name = name;
            return View();
        }

    }
}
//----------------------------------------------------NOTES for Passing Data-----------------------------------------------------------------------
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//ViewData and ViewBag are temporary becasue when the data is transfered from one request to anothor the data gets lost or the object becomes null (ViewData is a dictionary object which means Key-Value object)
//TempData the data can be transmitted for more than one  request, with the help of "keep" method we can retain the value.
//Session helps to store the data throughout the application lifecycle until we remove it.
//Cookies are persistent and not persistent depends on how do you want to store the data.
//QueryString the data travels from one request to another through the URL.
