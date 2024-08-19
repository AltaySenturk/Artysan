using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;
using Artysan_Entities.UnitOfWorks;
using Artysan_Entities.ViewModels;
using AutoMapper;

namespace Artysan_Service.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public LocationService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAll()
        {
            var list =await _uow.GetRepository<Location>().GetAll();
            return _mapper.Map<IEnumerable<LocationViewModel>>(list);

        }
        public async Task Add(LocationViewModel model)
        {
          var eventArtist = _mapper.Map<Location>(model);
          await _uow.GetRepository<Location>().Add(eventArtist);
        }

        public async Task<LocationViewModel> Get(int id)
        {
              var eventt = await _uow.GetRepository<Location>().GetByIdAsync(id);
            return _mapper.Map<LocationViewModel>(eventt);;
        }

        public async Task Update(LocationViewModel model)
        {
             var eventArtist = _mapper.Map<Location>(model);
            _uow.GetRepository<Location>().Update(eventArtist);
        }

        public async Task Delete(int Id)
        {
            var eventArtist = await _uow.GetRepository<Location>().GetByIdAsync(Id);
           _uow.GetRepository<Location>().Delete(eventArtist);
        }

    }
    
    }
