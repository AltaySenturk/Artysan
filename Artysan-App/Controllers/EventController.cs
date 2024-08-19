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

        public async Task<IActionResult> Index(string? search)
        {
            var list = await _eventService.GetAll();
            if (search != null)
			{
				list = list.Where(a => a.Name.ToLower().Contains(search.ToLower())).ToList();
			}
            return View(list);
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
        
    }
}