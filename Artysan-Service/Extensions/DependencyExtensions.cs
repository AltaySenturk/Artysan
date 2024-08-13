using Artysan_DAL.Contexts;
using Artysan_DAL.Models;
using Artysan_DAL.UnitOfWorks;
using Artysan_Entities.UnitOfWorks;
using Artysan_Service.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Service.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddExtensions(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(
               opt =>
               {
                   opt.Password.RequiredLength = 3;    //default 6 karakter
                   opt.Password.RequireNonAlphanumeric = false;
                   opt.Password.RequireUppercase = false;
                   opt.Password.RequireLowercase = false;
                   opt.Password.RequireDigit = false;
                   opt.User.RequireUniqueEmail = true;  //aynı email adresinin tekrar kullanılmasına izin vermez.

                   opt.User.AllowedUserNameCharacters = "abcdefghijklmnoprstuvyz0123456789"; //kullanıcı adı girilirken bunlardan başka birkarakter girilmesine izin vermez.
                   opt.Lockout.MaxFailedAccessAttempts = 3;  //default 5
                   opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1); //default 5
               }).AddEntityFrameworkStores<ArtysanDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddAutoMapper(typeof(MappingProfile));
        }

    }
}
