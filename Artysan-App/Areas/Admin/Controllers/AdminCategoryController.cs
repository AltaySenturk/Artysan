using Artysan_Entities.Interfaces;
using Artysan_Service.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public AdminCategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
            var events = await _categoryService.GetAll();
            return View(events);
        }
    }
}
