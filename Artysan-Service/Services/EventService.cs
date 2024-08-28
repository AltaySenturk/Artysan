using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_DAL.UnitOfWorks;
using Artysan_Entities.Entites;
using Artysan_Entities.Interfaces;
using Artysan_Entities.UnitOfWorks;
using Artysan_Entities.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Artysan_Service.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IRepository<Event> _eventRepository;


        public EventService(IUnitOfWork uow, IMapper mapper, IRepository<Event> eventRepository)
        {
            _uow = uow;
            _mapper = mapper;
            _eventRepository = eventRepository;
        }

        public  async Task<IEnumerable<EventViewModel>> GetAll()
        {
            var list = await _uow.GetRepository<Event>().GetAll();
            return _mapper.Map<IEnumerable<EventViewModel>>(list);

        }
     
         public void Add(EventViewModel model)
        {
          var eventArtist = _mapper.Map<Event>(model);
           _uow.GetRepository<Event>().Add(eventArtist);
           _uow.Commit();
        }

        public async Task<EventViewModel> Get(int id)
        {
              var eventt = await _uow.GetRepository<Event>().GetByIdAsync(id);
            return _mapper.Map<EventViewModel>(eventt);
        }

        public async Task Update(EventViewModel model)
        {
             var eventArtist = _mapper.Map<Event>(model);
            _uow.GetRepository<Event>().Update(eventArtist);
        }

        public void Delete(int id)
        {
            var eventToDelete = _eventRepository.GetById(id);
            if (eventToDelete != null)
            {
                _eventRepository.Delete(eventToDelete);
                _uow.Commit();
            }
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
        //
        public Event GetById(int id)
        {
            return _eventRepository.GetById(id);
        }
		public void Update(Event eventToUpdate)
		{
			var existingEvent = _eventRepository.GetById(eventToUpdate.Id);
			if (existingEvent != null)
			{
				_mapper.Map(eventToUpdate, existingEvent);
				_uow.Commit();
			}
		}

        public async Task<IEnumerable<EventViewModel>> Getting()
        {
            var list = await _uow.GetRepository<Event>().GetAll();
            return _mapper.Map<IEnumerable<EventViewModel>>(list);
        }
    }
} 
    