using Artysan_DAL.Models;
using Artysan_Entities.Entites;
using Artysan_Entities.Entities;
using Artysan_Entities.Interfaces;
using Artysan_Entities.UnitOfWorks;
using Artysan_Entities.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Service.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IUnitOfWork _uow;
		private readonly IMapper _mapper;


		public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper, IUnitOfWork uow)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_mapper = mapper;
			_uow = uow;
		}
		public async Task<string> CreateUserAsync(RegisterViewModel model)
		{
			string message = string.Empty;
			AppUser user = new AppUser()
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				UserName = model.UserName
			};
			var identityResult = await _userManager.CreateAsync(user, model.Password);

			if (identityResult.Succeeded)
			{
				message = "OK";
			}
			else
			{
				foreach (var error in identityResult.Errors)
				{
					message = error.Description;
				}
			}
			return message;
		}
		public async Task<UserViewModel> Find(string username)
		{
			var user = await _userManager.FindByNameAsync(username);
			return _mapper.Map<UserViewModel>(user);
		}
		public async Task<LoginResult> FindByNameAsync(LoginViewModel model)
		{
			var user = await _userManager.FindByNameAsync(model.UserName);
			if (user == null)
			{
				return new LoginResult { Status = "Kullanıcı bulunamadı!" };
			}

			var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
			if (result.Succeeded)
			{
				var userViewModel = new UserViewModel
				{
					Id = user.Id,
					UserName = user.UserName,
					FirstName = user.FirstName,
					LastName = user.LastName,
					PhoneNumber=user.PhoneNumber,
					Email = user.Email,
					// Add other properties as needed
				};

				// If you still want to set individual session values

				return new LoginResult { Status = "OK", User = userViewModel };
			}

			return new LoginResult { Status = "Şifre yanlış!" };




			/*
			string message = string.Empty;
			var user = await _userManager.FindByNameAsync(model.UserName);
			if (user == null)
			{
				message = "Kullanıcı bulunamadı!";
				return message;
			}
			var signInResult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

			if (signInResult.Succeeded)
			{
				message = "OK";
			}
			return message;
		}
		public async Task SignOutAsync()
		{
			await _signInManager.SignOutAsync();*/
		}
		public async Task SignOutAsync()
		{
			await _signInManager.SignOutAsync();
		}


		public async Task<string> CreateRoleAsync(RoleViewModel model)
		{
			string message = string.Empty;
			AppRole role = new AppRole()
			{
				Name = model.Name,
				Description = model.Description,
			};
			var identityResult = await _roleManager.CreateAsync(role);

			if (identityResult.Succeeded)
			{
				message = "OK";
			}
			else
			{
				foreach (var error in identityResult.Errors)
				{
					message = error.Description;
				}
			}
			return message;
		}

		public async Task<List<RoleViewModel>> GetAllRoles()
		{
			var roles = await _roleManager.Roles.ToListAsync();
			return _mapper.Map<List<RoleViewModel>>(roles);
		}

		public Task<List<UserViewModel>> GetAllUsers()
		{
			throw new NotImplementedException();
		}
		public async Task<UsersInOrOutRoleViewModel> GetAllUsersInOrOutRole(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);

			var usersInRole = new List<AppUser>();
			var usersOutRole = new List<AppUser>();

			var users = await _userManager.Users.ToListAsync();

			foreach (var user in users)
			{
				if (await _userManager.IsInRoleAsync(user, role.Name))
				{
					usersInRole.Add(user); //Rolde bulunan kulanıcılara ekle.
				}
				else
				{
					usersOutRole.Add(user); //Rolde olmayan kulanıcılara ekle.
				}
			}
			UsersInOrOutRoleViewModel model = new UsersInOrOutRoleViewModel()
			{
				Role = _mapper.Map<RoleViewModel>(role),
				UsersInRole = _mapper.Map<List<UserViewModel>>(usersInRole),
				UsersOutRole = _mapper.Map<List<UserViewModel>>(usersOutRole),
			};
			return model;
		}
		public async Task<string> EditRoleListAsync(EditRoleViewModel model)
		{
			string message = "OK";

			foreach (var userId in model.UsersIdsToAdd ?? new string[] { })
			{
				var user = await _userManager.FindByIdAsync(userId);
				if (user != null)
				{
					var result = await _userManager.AddToRoleAsync(user, model.RoleName);
					if (!result.Succeeded)
						message += $"{user.UserName} role eklenemedi.";
				}
			}

			foreach (var userId in model.UsersIdsToDelete ?? new string[] { })
			{
				var user = await _userManager.FindByIdAsync(userId);
				if (user != null)
				{
					var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
					if (!result.Succeeded)
						message += $"{user.UserName} rolden çıkarılamadı.";
				}
			}
			return message;
		}
		public async Task DeleteRoleAsync(string id)
		{
			var role = await _roleManager.FindByIdAsync(id);
			await _roleManager.DeleteAsync(role);
		}

		public async Task<UserViewModel> Get(int id)
		{
			var eventt = await _uow.GetRepository<AppUser>().GetByIdAsync(id);
			return _mapper.Map<UserViewModel>(eventt);
		}

		public async Task Add(UserViewModel user)
		{

			var eventArtist = _mapper.Map<AppUser>(user);
			await _uow.GetRepository<AppUser>().Add(eventArtist);
		}

		public async Task Update(UserViewModel user)
		{
			var eventArtist = _mapper.Map<AppUser>(user);
			_uow.GetRepository<AppUser>().Update(eventArtist);
		}

		public async Task Delete(int Id)
		{
			var eventArtist = await _uow.GetRepository<AppUser>().GetByIdAsync(Id);
			_uow.GetRepository<AppUser>().Delete(eventArtist);
		}

		public List<LoginViewModel> GetAll()
		{
			var users = _uow.GetRepository<UserViewModel>().GetAll();
			var userViewModels = _mapper.Map<List<LoginViewModel>>(users);
			return userViewModels;

		}

	
}
}
