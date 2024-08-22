using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.ViewModels;

namespace Artysan_Entities.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketViewModel>> GetAll();
        Task<TicketViewModel> Get(int id);

        Task Add(TicketViewModel model);
        Task Update(TicketViewModel model);
        Task Delete(int Id);
    }
}