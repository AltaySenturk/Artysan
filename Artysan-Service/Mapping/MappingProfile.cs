using Artysan_Entities.Entites;
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
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();  
            CreateMap<EventArtist, EventArtistViewModel>().ReverseMap();
        }
    }
}
