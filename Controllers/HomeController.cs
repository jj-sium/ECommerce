using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ghinelli.johan._5h.Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ghinelli.johan._5h.Ecommerce.Helpers;

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
public IActionResult Privacy(){
    return View();
}
        public IActionResult Index()
        {
            
          
            return View();
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
