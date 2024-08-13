﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.Models
{
	public class AppUser : IdentityUser<int>
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
