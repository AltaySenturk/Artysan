using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.ViewComponents
{
    public class FutureViewComponent : ViewComponent
    {
        private readonly IEventService _eventService;

        public FutureViewComponent(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var eventi = await _eventService.Getting();
            eventi = eventi.Where(m => m.IsFuture == true);
          
            return View(eventi);
        }
    }
}