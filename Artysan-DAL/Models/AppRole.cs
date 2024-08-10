using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.Models
{
	public class AppRole : IdentityRole<int>
	{
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
