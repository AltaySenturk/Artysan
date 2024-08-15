using Artysan_DAL.Models;
using Artysan_Entities.Interfaces;
using Artysan_Entities.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artysan_Service.Services
{


    public class CustomerService : ICustomerService
    {
        private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IMapper _mapper;

		public CustomerService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager, IMapper mapper)
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
		public async Task<CustomerViewModel> Find(string username)
		{
			var user = await _userManager.FindByNameAsync(username);
			return _mapper.Map<CustomerViewModel>(user);
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

		public Task<List<RoleViewModel>> GetAllRoles()
		{
			throw new NotImplementedException();
		}

		public Task<List<CustomerViewModel>> GetAllUsers()
		{
			throw new NotImplementedException();
		}
	}
    
    }