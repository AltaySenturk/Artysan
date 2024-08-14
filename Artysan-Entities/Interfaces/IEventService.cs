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
		 Task<IEnumerable<EventArtistViewModel>> GetAll();
        Task<EventArtistViewModel> Get(int id);

        Task Add(EventArtistViewModel model);
		Task Update(EventArtistViewModel model);
		Task Delete(int Id);

	}
}
