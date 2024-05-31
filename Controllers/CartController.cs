using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ghinelli.johan._5h.Ecommerce.Models;
using ghinelli.johan._5h.Ecommerce.Helpers;

namespace ghinelli.johan._5h.Ecommerce.Controllers
{
    public class CartController : Controller
    {
        private readonly dbContext _context;

        public CartController()
        {
            _context = new dbContext();
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") ?? new List<CartItem>();
            ViewBag.Cart = cart;
            ViewBag.Total = cart.Sum(item => item.Auto.Prezzo * item.Quantity);
            return View("~/Views/Cart/Index.cshtml");
        }

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var auto = _context.Auto.SingleOrDefault(a => a.Id == id);
            if (auto == null)
            {
                return NotFound();
            }

            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") ?? new List<CartItem>();

            var cartItem = cart.SingleOrDefault(c => c.AutoId == id);
            if (cartItem == null)
            {
                cart.Add(new CartItem { AutoId = id, Auto = auto, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

       [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartItem>>(HttpContext.Session, "cart") ?? new List<CartItem>();
            var cartItem = cart.SingleOrDefault(c => c.AutoId == id);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index", "cart");
        }
    }

    
}
