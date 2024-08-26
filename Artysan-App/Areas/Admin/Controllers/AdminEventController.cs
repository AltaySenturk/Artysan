using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Artysan_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class AdminEventController : Controller
	{
		private readonly IEventService _eventService;

		public AdminEventController(IEventService eventService)
		{
			_eventService = eventService;
		}

		public async Task<IActionResult> Index()
		{
			var events = await _eventService.GetAll();
			return View(events);
		}
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(EventViewModel model)
		{
			if (ModelState.IsValid)
			{
				ModelState.AddModelError("", "Kullanıcı kaydı gerçekleşmedi!");
				return View(model);
			}

			_eventService.Add(model);
			return RedirectToAction("Index");
		}
	}
}
