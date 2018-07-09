using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AdApp.Models;
using AdData.Models;
using AdData;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index([Bind("Id", "Username", "Password", "Email", "FirstName", "LastName", "TelephoneNumber")] User user)
        {

            User secondUser = _context.Users.FirstOrDefault(e => e.Username == user.Username);
            if (secondUser != null)
            {
                if (secondUser.Password.Equals(user.Password))
                {
                    CurrentUser.User = user;
                    return RedirectToAction(nameof(Index), "Ads");
                }
            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Id", "Username", "Password", "Email", "FirstName", "LastName", "TelephoneNumber")] User user)
        {
            if (ModelState.IsValid && user != null)
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Logout()
        {
            CurrentUser.User = null;
            return RedirectToAction(nameof(Index));
        }
        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
