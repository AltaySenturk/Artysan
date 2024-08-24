using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Artysan_Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAll();
            return View(events);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EventViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {                  
                    _eventService.Add(model);
                    
                    TempData["SuccessMessage"] = "Event created successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    
                    TempData["ErrorMessage"] = "An error occurred: " + ex.Message;
                }
            }

            
            return View(model);
        }
    }
}
