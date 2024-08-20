using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Artysan_Service.Extensions;
using Artysan_Entities.Entites;

namespace Artysan_App.Controllers
{
    public class CartController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ICartService _cartService;

        public CartController(IEventService eventService, ICartService cartService)
        {
            _eventService = eventService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            var cart = GetCart(); 
            TempData["ToplamAdet"] = _cartService.TotalQuantity(cart);
            if (_cartService.TotalPrice(cart) > 0)
                TempData["ToplamTutar"] = _cartService.TotalPrice(cart);
            return View(cart);
        }
        public void SetCart(List<CartViewModel> sepet) 
        {
            HttpContext.Session.SetJson("sepet", sepet);    
        }
        public IActionResult Add(List<CartViewModel> model, int Id, int Adet)
        {
            var eventt = _eventService.Get(Id);
            var cartItem = _cartService.AddToCart;
            var cart = GetCart();               //sepetimi istiyorum (ilk olarak boş sepet)

            model. = Id;    
            _cartService.MovieName = Event.Name;
            _cartService. = Adet;
            _cartService.MoviePrice = movie.Price;

            cart = cartItem.AddToCart(cart, cartItem);

            SetCart(cart);

            return RedirectToAction("Index");

        }
        public List<CartViewModel> GetCart()     
        {
            var sepet = HttpContext.Session.GetJson<List<CartViewModel>>("sepet") ?? new List<CartViewModel>();
            
            return sepet;
        }
    }
}
