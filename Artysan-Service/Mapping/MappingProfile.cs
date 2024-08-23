using Artysan_DAL.Models;
using Artysan_Entities.Entites;
using Artysan_Entities.Entities;
using Artysan_Entities.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Service.Mapping
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            
            CreateMap<Event, EventViewModel>();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Location, LocationViewModel>().ReverseMap();
            CreateMap<Cart, CartViewModel>().ReverseMap();
            CreateMap<Ticket, TicketViewModel>().ReverseMap();
            CreateMap<AppUser, UserViewModel>().ReverseMap();
            CreateMap<AppUser, LoginViewModel>().ReverseMap();
            CreateMap<EventArtist, EventArtistViewModel>().ReverseMap();
            CreateMap<EventSale, EventSaleViewModel>().ReverseMap();
            CreateMap<EventSaleDetail, EventSaleDetailViewModel>().ReverseMap();
            CreateMap<Task<IEnumerable<UserViewModel>>, List<LoginViewModel>>();
            CreateMap<Task<IEnumerable<UserViewModel>>, List<LoginViewModel>>();
            CreateMap<AppRole, RoleViewModel>().ReverseMap();

        }
    }
}
