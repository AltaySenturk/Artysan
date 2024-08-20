using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace Artysan_App.ViewComponents
{
    public class LocationViewComponent : ViewComponent
    {
         private readonly ILocationService _locService;

        public LocationViewComponent(ILocationService locService)
        {
            _locService = locService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loc = await _locService.GetAll();
            return View(loc);
        }
    }
}