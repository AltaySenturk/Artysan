using Artysan_App.Models;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Artysan_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICartService _cartService;
       
        List<CartViewModel> cart = new List<CartViewModel>();

        public HomeController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            cart = GetCart();
            // Retrieve the cart from the session or some other storage
            TempData["ToplamAdet"] = _cartService.TotalQuantity(cart).ToString();
            if (_cartService.TotalPrice(cart) > 0)
                TempData["ToplamTutar"] = _cartService.TotalPrice(cart).ToString();


            return View();
        }
            private List<CartViewModel> GetCart()
        {
            var cart = HttpContext.Session.GetString("cart");
            return cart == null ? new List<CartViewModel>() : JsonConvert.DeserializeObject<List<CartViewModel>>(cart);
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
    }
}
