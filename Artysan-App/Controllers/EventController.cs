using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Artysan_App.Controllers
{

    public class EventController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IEventService _eventService;



        public EventController(ICategoryService categoryService, IEventService eventService)
        {
            _categoryService = categoryService;
            _eventService = eventService;

        }

        public async Task<IActionResult> Index(string? search, int? category, int? location, string? date)
        {
            var list = await _eventService.GetAll();
            if (search != null)
            {
                list = list.Where(a => a.Name.ToLower().Contains(search.ToLower())).ToList();
            }
            if (category != null)
            {
                list = list.Where(a => a.CategoryId.HasValue && a.CategoryId.Value == category).ToList();
            }

            if (location != null)
            {
                list = list.Where(a => a.LocationId.HasValue && a.LocationId.Value == location).ToList();
            }

            if (!string.IsNullOrEmpty(date))
            {
                if (DateTime.TryParse(date, out DateTime parsedDate))
                {
                    list = list.Where(a => DateTime.TryParse(a.EventDate, out DateTime eventDate) && eventDate.Date == parsedDate.Date).ToList();
                }
                else
                {
                    // Handle invalid date input
                }
            }

            return PartialView("_Eventlist", list);
        }


        public async Task<IActionResult> Sport(int? id)
        {
            var cat = await _eventService.GetSportEvents(3);
            return View(cat);
            /*
            var cat = await _eventService.GetAll();
            if (id != null)
            {
                cat = cat.Where(c => c.CategoryId == id).ToList();
            } */
        }
        public async Task<IActionResult> Theater(int? id)
        {
            var cat = await _eventService.GetTheaterEvents(2);
            return View(cat);
            /*
            var cat = await _eventService.GetAll();
            if (id != null)
            {
                cat = cat.Where(c => c.CategoryId == id).ToList();
            } */
        }
        public async Task<IActionResult> Cinema(int? id)
        {
            var cat = await _eventService.GetCinemaEvents(4);
            return View(cat);
            /*
            var cat = await _eventService.GetAll();
            if (id != null)
            {
                cat = cat.Where(c => c.CategoryId == id).ToList();
            } */
        }
        public async Task<IActionResult> Concert(int? id)
        {
            var cat = await _eventService.GetConcertEvents(1);
            return View(cat);
            /*
            var cat = await _eventService.GetAll();
            if (id != null)
            {
                cat = cat.Where(c => c.CategoryId == id).ToList();
            } */
        }
        public async Task<IActionResult> Workshop(int? id)
        {
            var cat = await _eventService.GetWorkshopEvents(5);
            return View(cat);
            /*
            var cat = await _eventService.GetAll();
            if (id != null)
            {
                cat = cat.Where(c => c.CategoryId == id).ToList();
            } */
        }
        public async Task<IActionResult> Details(int id)    //id -> movie.Id
        {
            
            var detay = await _eventService.Get(id);
                var detayList = new List<EventViewModel> { detay };

            return View(detayList);
        }
    }
}