using Artysan_Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Entities.Interfaces
{
    public interface IAccountService
    {
        Task<string> CreateUserAsync(RegisterViewModel model);
        Task<string> FindByNameAsync(LoginViewModel model);
        Task<UserViewModel> Find(string username);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<RoleViewModel>> GetAllRoles();
        Task<UsersInOrOutRoleViewModel> GetAllUsersInOrOutRole(string id);
        Task<string> EditRoleListAsync(EditRoleViewModel model);
        Task DeleteRoleAsync(string id);

        Task SignOutAsync();

    }
}
