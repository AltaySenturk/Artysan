using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.ViewModels;

namespace Artysan_Entities.Interfaces
{
    public interface IEventSaleDetailService
    {
        public Task<List<EventSaleDetailViewModel>> GetAll();
        public Task<EventSaleDetailViewModel> Get(int id);
        public bool AddRange(List<CartViewModel> cart, int _paymentId);
        public Task<EventSaleDetailViewModel> Add(EventSaleDetailViewModel model);
        public Task Update(EventSaleDetailViewModel model);
        public Task Delete(int id);
        public Task Delete(EventSaleDetailViewModel model);
    }
}