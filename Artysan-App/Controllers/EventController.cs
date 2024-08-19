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

        public IActionResult Index()
        {
            return View();
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
    }
}