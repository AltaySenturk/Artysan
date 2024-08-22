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
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EventViewModel>> GetAll()
        {
            var list =await _uow.GetRepository<Event>().GetAll();
            return _mapper.Map<IEnumerable<EventViewModel>>(list);

        }
     
         public async Task Add(EventViewModel model)
        {
          var eventArtist = _mapper.Map<Event>(model);
          await _uow.GetRepository<Event>().Add(eventArtist);
        }

        public async Task<EventViewModel> Get(int id)
        {
              var eventt = await _uow.GetRepository<Event>().GetByIdAsync(id);
            return _mapper.Map<EventViewModel>(eventt);;
        }

        public async Task Update(EventViewModel model)
        {
             var eventArtist = _mapper.Map<Event>(model);
            _uow.GetRepository<Event>().Update(eventArtist);
        }

        public async Task Delete(int Id)
        {
            var eventArtist = await _uow.GetRepository<Event>().GetByIdAsync(Id);
           _uow.GetRepository<Event>().Delete(eventArtist);
        }

        public async Task<IEnumerable<EventViewModel>> GetSportEvents(int Id)
        {
            var events = await _uow.GetRepository<Event>().GetAll();
            var locations = await _uow.GetRepository<Location>().GetAll();

            var sportEvents = events.Where(e => e.CategoryId == Id);
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(sportEvents);

            foreach (var eventViewModel in eventViewModels)
            {
                eventViewModel.Location = _mapper.Map<LocationViewModel>(
                    locations.FirstOrDefault(l => l.Id == eventViewModel.LocationId));
            }

            return eventViewModels;
        }

        public async Task<IEnumerable<EventViewModel>> GetTheaterEvents(int Id)
        {
           var events = await _uow.GetRepository<Event>().GetAll();
            var locations = await _uow.GetRepository<Location>().GetAll();

            var sportEvents = events.Where(e => e.CategoryId == Id);
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(sportEvents);

            foreach (var eventViewModel in eventViewModels)
            {
                eventViewModel.Location = _mapper.Map<LocationViewModel>(
                    locations.FirstOrDefault(l => l.Id == eventViewModel.LocationId));
            }

            return eventViewModels;
        }

        public async Task<IEnumerable<EventViewModel>> GetCinemaEvents(int Id)
        {
           var events = await _uow.GetRepository<Event>().GetAll();
            var locations = await _uow.GetRepository<Location>().GetAll();

            var sportEvents = events.Where(e => e.CategoryId == Id);
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(sportEvents);

            foreach (var eventViewModel in eventViewModels)
            {
                eventViewModel.Location = _mapper.Map<LocationViewModel>(
                    locations.FirstOrDefault(l => l.Id == eventViewModel.LocationId));
            }

            return eventViewModels;
        }

        public async Task<IEnumerable<EventViewModel>> GetConcertEvents(int Id)
        {
            var events = await _uow.GetRepository<Event>().GetAll();
            var locations = await _uow.GetRepository<Location>().GetAll();

            var sportEvents = events.Where(e => e.CategoryId == Id);
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(sportEvents);

            foreach (var eventViewModel in eventViewModels)
            {
                eventViewModel.Location = _mapper.Map<LocationViewModel>(
                    locations.FirstOrDefault(l => l.Id == eventViewModel.LocationId));
            }

            return eventViewModels;
        }

        public async Task<IEnumerable<EventViewModel>> GetWorkshopEvents(int Id)
        {
            var events = await _uow.GetRepository<Event>().GetAll();
            var locations = await _uow.GetRepository<Location>().GetAll();

            var sportEvents = events.Where(e => e.CategoryId == Id);
            var eventViewModels = _mapper.Map<IEnumerable<EventViewModel>>(sportEvents);

            foreach (var eventViewModel in eventViewModels)
            {
                eventViewModel.Location = _mapper.Map<LocationViewModel>(
                    locations.FirstOrDefault(l => l.Id == eventViewModel.LocationId));
            }

            return eventViewModels;
        }
    }
} 
    