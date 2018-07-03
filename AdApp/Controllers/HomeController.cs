using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdApp.Models;
using AdData.Models;
using AdData;

namespace AdApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly AdContext _context;

        public HomeController(AdContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact([Bind("Id", "Username", "Password", "Email", "FirstName", "LastName", "TelephoneNumber")] User user)
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
