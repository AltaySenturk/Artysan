using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.Entites;
using Artysan_Entities.ViewModels;

namespace Artysan_Entities.Interfaces
{
    public interface IEventSaleService
    {
        Task<List<EventSaleViewModel>> GetAll();
        Task<EventSaleViewModel> Get(int id);
        int AddSale(EventSaleViewModel model);
        Task<EventSaleViewModel> Add(EventSaleViewModel model);

        Task Update(EventSaleViewModel model);
        Task Delete(int id);

    }
}