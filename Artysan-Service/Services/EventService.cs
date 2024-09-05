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

        public async Task<IEnumerable<EventViewModel>> GetAll()
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
        public async Task<EventViewModel> GetId(int Id)
        {
            var eventRepo = _uow.GetRepository<Event>();
            var locationRepo = _uow.GetRepository<Location>();
            var ticketRepo = _uow.GetRepository<Ticket>();

            var eventEntity = eventRepo.GetById(Id);
            if (eventEntity == null)
            {
                return null;
            }

            var locationEntity = locationRepo.GetById(eventEntity.LocationId);
            var ticketEntity = ticketRepo.GetById(eventEntity.TicketId);

            var eventViewModel = _mapper.Map<EventViewModel>(eventEntity);
            eventViewModel.Location = _mapper.Map<LocationViewModel>(locationEntity);
            eventViewModel.Ticket = _mapper.Map<TicketViewModel>(ticketEntity);

            return eventViewModel;
        }
        public async Task<bool> Update(EventViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var eventEntity = _mapper.Map<Event>(model);
            _uow.GetRepository<Event>().Update(eventEntity);

            try
            {
                _uow.CommitAsync();
                return true; // Update was successful
            }
            catch (DbUpdateException)
            {
                // Handle specific database update exceptions
                return false; // Indicate failure
            }
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

        public EventViewModel Update(EventViewModel model, int id)
        {
            var eventToUpdate = _eventRepository.GetById(id);
            if (eventToUpdate == null)
            {
                return(model);
            }

            // Update the event properties from the model
            eventToUpdate.Name = model.Name;
            eventToUpdate.EventDate = model.EventDate;
            eventToUpdate.IsPopular = model.IsPopular;
            eventToUpdate.IsFuture = model.IsFuture;
            eventToUpdate.Description = model.Description;
            eventToUpdate.Stock = model.Stock;
            eventToUpdate.ImageUrl = model.ImageUrl;
            eventToUpdate.CategoryId = model.CategoryId;

            _eventRepository.Update(eventToUpdate);
            _uow.Commit();

            return (model);
        }


        public async Task<IEnumerable<EventViewModel>> Getting()
        {
            var list = await _uow.GetRepository<Event>().GetAll();
            return _mapper.Map<IEnumerable<EventViewModel>>(list);
        }


    }
}
