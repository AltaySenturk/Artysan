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
    public class EventSaleService : IEventSaleService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EventSaleService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<EventSaleViewModel> Add(EventSaleViewModel model)
        {
              var eventSaleDetail = _mapper.Map<EventSale>(model);
            var addedEntity = _uow.GetRepository<EventSale>().Add(eventSaleDetail);
            return _mapper.Map<EventSaleViewModel>(addedEntity);
        }


        public int AddSale(EventSaleViewModel model)
        {
            var eventsale = _mapper.Map<EventSale>(model);
            var sale = _uow.GetRepository<EventSale>().Add(eventsale);
            return sale.Id;

        }

        public async Task Delete(int id)
        {
            var eventArtist = await _uow.GetRepository<EventSale>().GetByIdAsync(id);
            _uow.GetRepository<EventSale>().Delete(eventArtist);
        }



        public async Task<EventSaleViewModel> Get(int id)
        {
            var eventt = await _uow.GetRepository<EventSale>().GetByIdAsync(id);
            return _mapper.Map<EventSaleViewModel>(eventt);
        }
        public async Task<List<EventSaleViewModel>> GetAll()
        {
            var sale = await _uow.GetRepository<EventSale>().GetAll();
            return _mapper.Map<List<EventSaleViewModel>>(sale);

        }

        public async Task Update(EventSaleViewModel model)
        {
            var eventArtist = _mapper.Map<EventSale>(model);
            _uow.GetRepository<EventSale>().Update(eventArtist);


        }
    }
    }
