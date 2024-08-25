using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Artysan_App.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
       private readonly IHttpContextAccessor _httpContextAccessor;
       private readonly ICartService _cartService;

        public CartViewComponent(IHttpContextAccessor httpContextAccessor, ICartService cartService)
        {
            _httpContextAccessor = httpContextAccessor;
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
    {
        var cartItems = GetCartItemsFromSession();
        var totalPrice = cartItems.Sum(item => item.Price * item.EventQuantity);

        var viewModel = new CartOverlayViewModel
        {
            CartItems = cartItems,
            TotalPrice = totalPrice
        };

        return View(viewModel);
    }

    private List<CartViewModel> GetCartItemsFromSession()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartJson = session.GetString("Cart");
        if (string.IsNullOrEmpty(cartJson))
        {
            return new List<CartViewModel>();
        }
        return JsonConvert.DeserializeObject<List<CartViewModel>>(cartJson);
    }
}
}