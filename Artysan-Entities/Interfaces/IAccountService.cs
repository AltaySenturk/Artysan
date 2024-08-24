using Artysan_Entities.Entities;
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
        Task<LoginResult> FindByNameAsync(LoginViewModel model);
        Task<UserViewModel> Find(string username);
        Task<string> CreateRoleAsync(RoleViewModel model);
        Task<List<UserViewModel>> GetAllUsers();
        Task<List<RoleViewModel>> GetAllRoles();
        Task<UsersInOrOutRoleViewModel> GetAllUsersInOrOutRole(string id);
        Task<string> EditRoleListAsync(EditRoleViewModel model);
        Task DeleteRoleAsync(string id);
        Task SignOutAsync();

        public List<LoginViewModel>GetAll();
        public Task <UserViewModel> Get(int id);

        public Task Add(UserViewModel user);
        public Task Update(UserViewModel user);
        Task Delete(int Id);

    }

}

