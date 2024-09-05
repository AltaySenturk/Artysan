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
    public class EventSaleDetailService : IEventSaleDetailService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public EventSaleDetailService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<EventSaleDetailViewModel> Add(EventSaleDetailViewModel model)
        {

            var eventSaleDetail = _mapper.Map<EventSaleDetail>(model);
            var addedEntity = _uow.GetRepository<EventSaleDetail>().Add(eventSaleDetail);
            return _mapper.Map<EventSaleDetailViewModel>(addedEntity);
        }

        public bool AddRange(List<CartViewModel> cart, int _paymentId)
        {
            var eventSale = _uow.GetRepository<EventSale>().GetById(_paymentId);
            if (eventSale == null)
            {

                // Handle the case where EventSale doesn't exist
                // You might want to create it here or throw an exception
                return false;
            }

            foreach (var item in cart)
            {
                EventSaleDetail movieSaleDetail = new EventSaleDetail()
                {
                    EventSaleId = _paymentId,
                    EventId = item.EventId,
                    Quantity = item.EventQuantity,
                    UnitPrice = item.EventPrice
                };
                _uow.GetRepository<EventSaleDetail>().Add(movieSaleDetail);
            }
            try
            {
                _uow.Commit();
                return true;
            }
            catch (System.Exception ex)
            {

                string message = ex.Message;
                return false;
            }
        }

        public async Task Delete(int id)
        {
            var eventArtist = await _uow.GetRepository<EventSaleDetail>().GetByIdAsync(id);
            _uow.GetRepository<EventSaleDetail>().Delete(eventArtist);
        }

        public Task Delete(EventSaleDetailViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<EventSaleDetailViewModel> Get(int id)
        {
            var eventt = await _uow.GetRepository<EventSaleDetail>().GetByIdAsync(id);
            return _mapper.Map<EventSaleDetailViewModel>(eventt);
        }

        public async Task<List<EventSaleDetailViewModel>> GetAll()
        {
            var sale = await _uow.GetRepository<EventSaleDetail>().GetAll();
            return _mapper.Map<List<EventSaleDetailViewModel>>(sale);

        }
        public async Task Update(EventSaleDetailViewModel model)
        {
            var eventArtist = _mapper.Map<EventSale>(model);
            _uow.GetRepository<EventSale>().Update(eventArtist);
        }
    }
}