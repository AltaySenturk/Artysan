using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Artysan_DAL.Models;
using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Artysan_Service.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace Artysan_App.Controllers
{

    public class ShoppingController : Controller
    {
        private readonly IAccountService _customerRepo;
        private readonly ICartService _cartRepo;
        private readonly IEventSaleService _eventSaleRepo;
        private readonly IEventSaleDetailService _eventSaleDetailRepo;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public ShoppingController(IAccountService customerRepo, ICartService cartRepo, IEventSaleService eventSaleRepo, IEventSaleDetailService eventSaleDetailRepo, IMapper mapper, IAccountService accountService)
        {
            _customerRepo = customerRepo;
            _cartRepo = cartRepo;
            _eventSaleRepo = eventSaleRepo;
            _eventSaleDetailRepo = eventSaleDetailRepo;
            _mapper = mapper;
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }
 
        public async Task<IActionResult> Checkout(LoginViewModel model)
        {

            if (User.Identity.IsAuthenticated)
            {
              
                return RedirectToAction("ConfirmAddress");
            }
            else
            {
                return RedirectToAction("Checking", "Account");
            }


        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{ 
        /*
            var result = await _accountService.FindByNameAsync(model);

            if (User.Identity.IsAuthenticated)
            {
                var userViewModel = result.User;
                HttpContext.Session.SetJson("user", userViewModel);
                return RedirectToAction("ConfirmAddress");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }*/


        //if (ModelState.IsValid)
        //{ 
        /*
        var customer = _customerRepo.GetAll().FirstOrDefault(c => c.User.Email == model.User.Email && c.Password == model.Password);
        if (customer == null)
        {
            ModelState.AddModelError("", "Hatalı email veya şifre girişi!");
        }
        else
        {
            HttpContext.Session.SetJson("user", customer);  //login olan customer bilgilerini session'a kayıt ediyoruz.
            return RedirectToAction("ConfirmAddress");
        }*/
        // }

        // }
        public IActionResult ConfirmAddress()
        {
            //Güvenlik için login olan kullanıcı bilgilerini session'dan çağırıp kontrol ediyoruz.
            var customer = HttpContext.Session.GetJson<UserViewModel>("user");
            if (customer == null)
            {
                //return RedirectToAction("Checkout");
            }
            return View(_mapper.Map<UserViewModel>(customer));
        }
        [HttpPost]
        public IActionResult ConfirmAddress(UserViewModel model)
        {
            _customerRepo.Update(_mapper.Map<UserViewModel>(model)); //view'dan gelen kullanıcı bilgilerinin son halini veritabanına update ediyoruz.
            HttpContext.Session.SetJson("user", model); //Kullanıcının bilgileri değişmiş olabileceğinden son halini session'a kayıt ediyoruz.
            return RedirectToAction("ConfirmPayment");
         //   return View();
        }
        public IActionResult ConfirmPayment()
        {
            var customer = HttpContext.Session.GetJson<AppUser>("user");
            if (customer == null)
            {
                return RedirectToAction("Login", "Account");
            }
            //sepet bilgileri session'dan çekilecek
            List<CartViewModel> cart = HttpContext.Session.GetJson<List<CartViewModel>>("cart");
            var toplamAdet = _cartRepo.TotalQuantity(cart);
            var toplamTutar = _cartRepo.TotalPrice(cart);

            EventSaleViewModel filmSatisViewModel = new EventSaleViewModel
            {
                Date = DateTime.Now,
                CustomerId = customer.Id,
                TotalQuantity = toplamAdet,
                TotalPrice = toplamTutar
            };

            CustomerReceiptViewModel customerFaturaViewModel = new CustomerReceiptViewModel()
            {
                userViewModel = _mapper.Map<UserViewModel>(customer),
                eventSaleViewModel = filmSatisViewModel,
                cartViews = cart,
            };

            return View(customerFaturaViewModel);
        }
        [HttpPost]
        public IActionResult ConfirmPayment(CustomerReceiptViewModel model)
        {
            //MovieSale nesnesi veritabanına kayıt edilerek sql'in vereceği Id bilgisi elde edilecek.
            var satisId = _eventSaleRepo.AddSale(_mapper.Map<EventSaleViewModel>(model.eventSaleViewModel));
            List<CartViewModel> cart = HttpContext.Session.GetJson<List<CartViewModel>>("cart");

            if (_eventSaleDetailRepo.AddRange(cart, satisId))
            {
                TempData["Message"] = "The Operation is Successfully Completed ";
                HttpContext.Session.Remove("sepet");
            }
            else
            {
                TempData["Message"] = "Operation is Successfully FAILED check it buddy";
            }

            return View("MessageShow");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {

            return View();
        }
    }
}
