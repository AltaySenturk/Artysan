using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Artysan_Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminEventController : Controller
	{
		private readonly IEventService _eventService;
		private readonly IMapper _mapper;

		public AdminEventController(IEventService eventService, IMapper mapper)
		{
			_eventService = eventService;
			_mapper = mapper;
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

		public IActionResult Delete(int id)
		{
			try
			{
				_eventService.Delete(id);
				return RedirectToAction("Index");
			}
			catch (Exception ex)
			{
				// Hata durumunda kullanıcıya mesaj gösterebilirsiniz.
				TempData["Error"] = "Silme işlemi sırasında bir hata oluştu.";
				return RedirectToAction("Index");
			}
		}
		public async Task<IActionResult> Edit(int id)
		{
			var eventViewModel = await _eventService.Get(id);
			if (eventViewModel == null)
			{
				return NotFound();
			}
			return View(eventViewModel);
		}

		// POST: Events/Edit/5
		[HttpPost]
		public async Task<IActionResult> Edit(int id, EventViewModel model)
		{
			if (id != model.Id)
			{
				return NotFound();
			}

			if (!ModelState.IsValid)
			{
				return View(model);
			}

			try
			{
				await _eventService.Update(model);
			}
			catch (Exception ex)
			{
				// Log the exception or handle it appropriately
				ModelState.AddModelError("", "An error occurred while updating the event.");
				return View(model);
			}

			return RedirectToAction("Index");
		}
	}
}
