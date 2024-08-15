using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _accountService;

        public AccountController(ICustomerService accountService)
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
			string msg = await _accountService.FindByNameAsync(model);
			if(msg == "Kullanıcı bulunamadı!")
			{
				ModelState.AddModelError("", msg);
				return View(model);
			}
			else if(msg == "OK")
			{
                return Redirect(model.ReturnUrl ?? "/Home/Index");
			}
			else
			{
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");
            }
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
