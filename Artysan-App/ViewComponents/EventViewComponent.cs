using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.ViewComponents
{
    public class EventViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;

        public EventViewComponent(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var eventi = await _eventService.GetAll();
            return View(eventi);
        }
    }
    }
