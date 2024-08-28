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
        private readonly IRepository<Location> _locationRepository;

        public LocationService(IUnitOfWork uow, IMapper mapper, IRepository<Location> locationRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public async Task<IEnumerable<LocationViewModel>> GetAll()
        {
            var list =await _uow.GetRepository<Location>().GetAll();
            return _mapper.Map<IEnumerable<LocationViewModel>>(list);

        }
        public void Add(LocationViewModel model)
        {
            var eventArtist = _mapper.Map<Location>(model);
            _uow.GetRepository<Location>().Add(eventArtist);
            _uow.Commit();
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

        //public async Task Delete(int Id)
        //{
        //    var eventArtist = await _uow.GetRepository<Location>().GetByIdAsync(Id);
        //   _uow.GetRepository<Location>().Delete(eventArtist);
        //}
        public void Delete(int id)
        {
            var locationToDelete = _locationRepository.GetById(id);
            if (locationToDelete != null)
            {
                _locationRepository.Delete(locationToDelete);
                _uow.Commit();
            }
        }

    }
    
    }
