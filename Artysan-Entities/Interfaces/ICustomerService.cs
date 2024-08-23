using Artysan_Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Entities.Interfaces
{
    public interface ICustomerService
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task<UserViewModel> Find(string username);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<UserViewModel>> GetAllUsers();
         Task<UserViewModel> GetAll();
        Task<List<RoleViewModel>> GetAllRoles();

        Task SignOutAsync();
    }
    
}
