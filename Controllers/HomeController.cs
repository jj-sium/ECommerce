using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ghinelli.johan._5h.Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ghinelli.johan._5h.Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        // Lista degli utenti registrati (simulazione di archiviazione dei dati)
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

        public IActionResult TabLogin()
        {
            string? NomeUtente = HttpContext.Session.GetString("username");
            if (string.IsNullOrEmpty(NomeUtente))
                return Redirect("/Home/Index"); // Corretta la redirezione

            dbContext db = new dbContext();
            return View(db);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
          [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

         [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Controllo se le credenziali corrispondono a quelle di un utente registrato
            var user = registeredUsers.FirstOrDefault(u => u.username == username && u.password == password);

            if (user != null)
            {
                // Autenticazione riuscita, reindirizza alla pagina principale
                return RedirectToAction("Index");
            }
            else
            {
                // Aggiungi un errore al modello di validazione per visualizzarlo nella vista
                ModelState.AddModelError(string.Empty, "Credenziali non valide");
                return View();
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password, string firstName, string lastName, DateTime dob)
        {
            // Creazione di un nuovo utente con le informazioni fornite
            var newUtente = new Utente
            {
                username = username,
                password = password,
            };

            // Aggiunta dell'utente alla lista degli utenti registrati
            registeredUsers.Add(newUtente);

            // Reindirizzamento alla pagina di login dopo la registrazione
            return RedirectToAction("Login");
        }
    }
}
