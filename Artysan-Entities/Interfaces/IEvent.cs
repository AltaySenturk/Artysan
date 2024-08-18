using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artysan_Entities.Entites;
using Artysan_Entities.ViewModels;

namespace Artysan_Entities.Interfaces
{
	public interface IEventService
	{
		 Task<IEnumerable<EventViewModel>> GetAll();
        Task<EventViewModel> Get(int id);

        Task Add(EventViewModel model);
		Task Update(EventViewModel model);
		Task Delete(int Id);

	}
}
