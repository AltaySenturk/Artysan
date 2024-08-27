using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Artysan_Service.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.Controllers
{
	public class AccountController : Controller
	{
		private readonly IAccountService _accountService;

		public AccountController(IAccountService accountService)
		{
			_accountService = accountService;
		}

		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Login(string? ReturnUrl)
		{
			LoginViewModel model = new LoginViewModel()
			{
				ReturnUrl = ReturnUrl
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel model)
		{
			var result = await _accountService.FindByNameAsync(model);

			if (result.Status == "Kullanıcı bulunamadı!")
			{
				ModelState.AddModelError(" kullancı yok", result.Status);
				return View(model);
			}
			else if (result.Status == "OK")
			{
                var userViewModel = result.User; // This should be a UserViewModel object
				HttpContext.Session.SetJson("user", userViewModel);
				return Redirect(model.ReturnUrl ?? "/Home/Index");
			}


			else
			{
				ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
			}
 


			// Handle other cases
			return View(model);


			/*
			string msg = await _accountService.FindByNameAsync(model);
			 var result = await _accountService.FindByNameAsync(model);
			if (msg == "Kullanıcı bulunamadı!")
			{
				ModelState.AddModelError("", msg);
				return View(model);
			}
			else if (msg == "OK")
			{
					HttpContext.Session.SetJson("user", msg);  //login olan customer bilgilerini session'a kayıt ediyoruz.
				return RedirectToAction("ConfirmAddress","Shopping");
				//return Redirect(model.ReturnUrl ?? "/Home/Index");
			}
 
			else
			{
				
				 ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!"); 
			}
			return View(model);*/

		}
		public async Task<IActionResult> Checking(string? ReturnUrl)
		{
			LoginViewModel model = new LoginViewModel()
			{
				ReturnUrl = ReturnUrl
			};
			return View(model);

		}
		[HttpPost] 
		public async Task<IActionResult> Checking(LoginViewModel model)
		{
			var result = await _accountService.FindByNameAsync(model);

			if (result.Status == "Kullanıcı bulunamadı!")
			{
				ModelState.AddModelError(" kullancı yok", result.Status);
				return View(model);
			}
			else if (result.Status == "OK")
			{
				var userViewModel = result.User; // This should be a UserViewModel object
				HttpContext.Session.SetJson("user", userViewModel);
				return Redirect(model.ReturnUrl ?? "/Shopping/ConfirmAddress");
			}


			else
			{
				ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
			}



			// Handle other cases
			return View(model);
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterViewModel model)
		{
			string msg = await _accountService.CreateUserAsync(model);
			if (msg == "OK")
			{
				return RedirectToAction("Login");
			}
			else
			{
				ModelState.AddModelError("", msg);
			}
			return View(model);
		}
		public async Task<IActionResult> Logout()
		{
			await _accountService.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
