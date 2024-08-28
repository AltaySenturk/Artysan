using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.ViewComponents
{
    public class PopularViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;

        public PopularViewComponent(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var eventi = await _eventService.Getting();
            eventi = eventi.Where(m => m.IsPopular == true);
          
            return View(eventi);
        }
    }
}