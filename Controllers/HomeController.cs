using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ghinelli.johan._5h.Ecommerce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ghinelli.johan._5h.Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private static List<Utente> registeredUsers = new List<Utente>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = registeredUsers.FirstOrDefault(u => u.username == username && u.password == password);

            if (user != null)
            {
              var usernameValue = user?.username ?? string.Empty;
                var claims = new List<Claim>
                    {
                       new Claim(ClaimTypes.Name, usernameValue)
                    };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Cerca", "Auto");
            }
            else
            {
                TempData["ErrorMessage"] = "Credenziali non valide";
                return View();
            }
        }

       
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            var newUtente = new Utente
            {
                username = username,
                password = password,
            };

            registeredUsers.Add(newUtente);

            return RedirectToAction("Login");
        }
     [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
    
}
