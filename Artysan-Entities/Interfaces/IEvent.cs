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

		public Task<IEnumerable<EventViewModel>> Getting();
		Task<IEnumerable<EventViewModel>> GetSportEvents(int Id);
		Task<EventViewModel> GetId(int id);
		Task<IEnumerable<EventViewModel>> GetTheaterEvents(int Id);
		Task<IEnumerable<EventViewModel>> GetCinemaEvents(int Id);
		Task<IEnumerable<EventViewModel>> GetConcertEvents(int Id);
		Task<IEnumerable<EventViewModel>> GetWorkshopEvents(int Id);
		Task<EventViewModel> Get(int id);

		void Add(EventViewModel model);
		Task Update(EventViewModel model);
        void Delete(int id);
		//
		Event GetById(int id);
		void Update(Event eventToUpdate);
	}
}
