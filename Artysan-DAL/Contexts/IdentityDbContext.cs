using Artysan_DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_DAL.Contexts
{
	public class IdentityDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
		public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
		{

		}
	}
}
