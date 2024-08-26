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
	[Authorize]
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
		[HttpGet]
		public IActionResult Edit(int id)
		{
			var eventToEdit = _eventService.GetById(id);
			if (eventToEdit == null)
			{
				return NotFound();
			}

			var eventModel = _mapper.Map<EventViewModel>(eventToEdit);
			return View(eventModel);
		}

		[HttpPost]
		public IActionResult Edit(EventViewModel model)
		{
			if (ModelState.IsValid)
			{
				var eventEntity = _mapper.Map<Event>(model);
				_eventService.Update(eventEntity);
				return RedirectToAction("Index");
			}

			return View(model);
		}
	}
}
