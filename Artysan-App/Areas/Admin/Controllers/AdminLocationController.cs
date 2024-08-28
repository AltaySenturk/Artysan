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
    public class AdminLocationController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly IMapper _mapper;

        public AdminLocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var events = await _locationService.GetAll();
            return View(events);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(LocationViewModel model)
        {
            if (ModelState.IsValid)
            {
                ModelState.AddModelError("", "Kullanıcı kaydı gerçekleşmedi!");
                return View(model);
            }

            _locationService.Add(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            try
            {
                _locationService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya mesaj gösterebilirsiniz.
                TempData["Error"] = "Silme işlemi sırasında bir hata oluştu.";
                return RedirectToAction("Index");
            }
        }
    }
}
