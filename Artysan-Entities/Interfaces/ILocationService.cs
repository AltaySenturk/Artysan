using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artysan_Entities.ViewModels;

namespace Artysan_Entities.Interfaces
{
    public interface ILocationService
    {
        Task<IEnumerable<LocationViewModel>> GetAll();
        Task<LocationViewModel> Get(int id);

        //Task Add(LocationViewModel model);
        Task Update(LocationViewModel model);
        //Task Delete(int Id);
        void Delete(int id);
        void Add(LocationViewModel model);
    }
}