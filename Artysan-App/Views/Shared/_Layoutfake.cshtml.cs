using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Artysan_App.Views.Shared
{
    public class _Layoutfake : PageModel
    {
        private readonly ILogger<_Layoutfake> _logger;

        public _Layoutfake(ILogger<_Layoutfake> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}