using Microsoft.AspNetCore.Mvc;
using PharmacyManagment.Data;
using PharmacyManagment.Models;
using System.Diagnostics;

namespace PharmacyManagment.Controllers
{
    public class HomeController : Controller
    {

        private readonly PharmcyContext _pharmcyContext;

        public HomeController(PharmcyContext pharmcyContext)
        {
            _pharmcyContext = pharmcyContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUpForm(Customer customer)
        {
            _pharmcyContext.Add(customer);
            _pharmcyContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
