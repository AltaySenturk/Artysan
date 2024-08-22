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
    public class TicketService : ITicketService
    {
         private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public TicketService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketViewModel>> GetAll()
        {
            var list =await _uow.GetRepository<Ticket>().GetAll();
            return _mapper.Map<IEnumerable<TicketViewModel>>(list);

        }
        public async Task Add(TicketViewModel model)
        {
          var eventArtist = _mapper.Map<Ticket>(model);
          await _uow.GetRepository<Ticket>().Add(eventArtist);
        }

        public async Task<TicketViewModel> Get(int id)
        {
              var eventt = await _uow.GetRepository<Ticket>().GetByIdAsync(id);
            return _mapper.Map<TicketViewModel>(eventt);;
        }

        public async Task Update(TicketViewModel model)
        {
             var eventArtist = _mapper.Map<Ticket>(model);
            _uow.GetRepository<Ticket>().Update(eventArtist);
        }

        public async Task Delete(int Id)
        {
            var eventArtist = await _uow.GetRepository<Ticket>().GetByIdAsync(Id);
           _uow.GetRepository<Ticket>().Delete(eventArtist);
        }

    }
    
    }

