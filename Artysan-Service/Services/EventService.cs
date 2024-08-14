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

        public async Task<IEnumerable<EventArtistViewModel>> GetAll()
        {
            var list =await _uow.GetRepository<EventArtist>().GetAll();
            return _mapper.Map<IEnumerable<EventArtistViewModel>>(list);

        }
        public async Task Add(EventArtistViewModel model)
        {
          var eventArtist = _mapper.Map<EventArtist>(model);
          await _uow.GetRepository<EventArtist>().Add(eventArtist);
        }

        public async Task<EventArtistViewModel> Get(int id)
        {
              var eventt = await _uow.GetRepository<EventArtist>().GetByIdAsync(id);
            return _mapper.Map<EventArtistViewModel>(eventt);;
        }

        public async Task Update(EventArtistViewModel model)
        {
             var eventArtist = _mapper.Map<EventArtist>(model);
            _uow.GetRepository<EventArtist>().Update(eventArtist);
        }

        public async Task Delete(int Id)
        {
            var eventArtist = await _uow.GetRepository<EventArtist>().GetByIdAsync(Id);
           _uow.GetRepository<EventArtist>().Delete(eventArtist);
        }
    }
}