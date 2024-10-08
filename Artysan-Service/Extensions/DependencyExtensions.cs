﻿using Artysan_DAL.Contexts;
using Artysan_DAL.Models;
using Artysan_DAL.Repositories;
using Artysan_DAL.UnitOfWorks;
using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;
using Artysan_Entities.UnitOfWorks;
using Artysan_Service.Mapping;
using Artysan_Service.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
                   opt.Password.RequiredLength = 6;
                   opt.Password.RequireNonAlphanumeric = false;
                   opt.Password.RequireUppercase = false;
                   opt.Password.RequireLowercase = false;
                   opt.Password.RequireDigit = false;
                   opt.User.RequireUniqueEmail = true;

                   opt.User.AllowedUserNameCharacters = "ABCDEFGHIJKLMNOPRSTUVXYWZabcdefghijklmnoprstuvwxyz0123456789_-";
                   opt.Lockout.MaxFailedAccessAttempts = 3;
                   opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
               }).AddEntityFrameworkStores<ArtysanDbContext>();

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IRepository<Event>, Repository<Event>>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped<IEventSaleService, EventSaleService>();
            services.AddScoped<IEventSaleDetailService, EventSaleDetailService>();
            services.AddScoped<IRepository<Location>, Repository<Location>>();

            //            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(typeof(MappingProfile));

        }

    }
}
