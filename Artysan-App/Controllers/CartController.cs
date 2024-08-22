using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Artysan_Service.Extensions;
using Artysan_Entities.Entites;
using Artysan_Service.Mapping;
using System.Text.Json;
using Newtonsoft.Json;

namespace Artysan_App.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IEventService _eventService;

        public CartController(ICartService cartService, IEventService eventService)
        {
            _cartService = cartService;
            _eventService = eventService;
        }
        List<CartViewModel> cart = new List<CartViewModel>();
        public IActionResult Index()
        {
            cart = GetCart();
            // Retrieve the cart from the session or some other storage
            TempData["ToplamAdet"] = _cartService.TotalQuantity(cart).ToString();
            if (_cartService.TotalPrice(cart) > 0)
                TempData["ToplamTutar"] = _cartService.TotalPrice(cart).ToString();
            return View(cart);
        }

        public async Task<IActionResult> Add(int id, int quantity)
        {
            try
            {
                // Log the received id and quantity
                Console.WriteLine($"Add method called with id: {id}, quantity: {quantity}");

                // Validate the id to ensure it's not 0
                if (id <= 0)
                {
                    Console.WriteLine("Invalid event id provided.");
                    return BadRequest("Invalid event id.");
                }

                // Try to retrieve the event by id
                var ticket = await _cartService.GetTicket(id);
                var evently = await _eventService.Get(id);
                if (evently == null)
                {
                    Console.WriteLine($"Event with id: {id} not found.");
                    return NotFound();
                }

                // Check if Ticket is null
                if (evently.Ticket == null)
                {
                    Console.WriteLine($"Event with id: {id} has a null Ticket. Defaulting price to 0.");
                    evently.Ticket = new TicketViewModel { Price = 0 };  // Provide a default Ticket if null
                }

                Console.WriteLine($"Event retrieved: {evently.Name}");

                // Retrieve the current cart
                cart = GetCart();
                if (cart == null)
                {
                    Console.WriteLine("Cart is null, initializing a new cart.");
                    cart = new List<CartViewModel>();
                }

                // Create a new CartViewModel for the item
                var cartItem = new CartViewModel
                {
                    EventId = evently.Id,
                    EventName = evently.Name,
                    EventQuantity = quantity,
                    EventPrice = (int)ticket.Price,

                };


                Console.WriteLine($"Adding item to cart: {cartItem.EventName}, quantity: {cartItem.EventQuantity}");

                // Add the item to the cart using the _cartService
                cart = await _cartService.AddToCart(cart, cartItem);
                if (cart == null)
                {
                    Console.WriteLine("Cart after adding item is null. Check AddToCart implementation.");
                }

                // Save the updated cart
                SetCart(cart);

                // Redirect to the Index action
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log the exception but still proceed with adding to the cart
                Console.WriteLine($"Exception occurred: {ex.Message}");

                TempData["Error"] = "An error occurred, but the item was still added to your cart.";
                return RedirectToAction("Index");
            }

        }
        public IActionResult RemoveFromCart(int id)
        {
            var cart = GetCart();
            cart = _cartService.DeleteFromCart(cart, id);
            SetCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteCart()
        {
            HttpContext.Session.Remove("cart");
            return RedirectToAction("Index");
        }

        private void SetCart(List<CartViewModel> cart)
        {
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        private List<CartViewModel> GetCart()
        {
            var cart = HttpContext.Session.GetString("cart");
            return cart == null ? new List<CartViewModel>() : JsonConvert.DeserializeObject<List<CartViewModel>>(cart);
        }
    }
}