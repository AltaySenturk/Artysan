﻿using Artysan_DAL.Models;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Service.Services
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;

		public AccountService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_mapper = mapper;
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
		public async Task<string> FindByNameAsync(LoginViewModel model)
		{
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
			await _signInManager.SignOutAsync();
		}
		public Task<string> CreateRoleAsync(RoleViewModel model)
		{
			throw new NotImplementedException();
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
	}
}
