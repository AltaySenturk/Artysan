using Artysan_Entities.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artysan_App.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminArtistController : Controller
    {
        private readonly IEventArtist _eventArtist;
        private readonly IMapper _mapper;

        public AdminArtistController(IMapper mapper, IEventArtist eventArtist)
        {
            _mapper = mapper;
            _eventArtist = eventArtist;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
