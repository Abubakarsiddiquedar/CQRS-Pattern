using Food.Application.DTOs;
using Food.Application.Enums;
using Food.Application.Exceptions;
using Food.Application.Interface;
using Food.Application.Wrapper;
using Food.Persistance.IdentityModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Persistance.SharedServices
{
	public class AccountService : IAccountService
	{
		private readonly UserManager<ApplicationUser> _userManager;
        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ApiResponse<Guid>> RegisterUser(RegisterRequest regiesterRequest)
        {
            var userExist = await _userManager.FindByEmailAsync(regiesterRequest.Email);
           if (userExist != null) 
            {
                throw new ApiException($"user already exist {regiesterRequest.Email} ");
            } 
			var userModel = new ApplicationUser
			{
				UserName = regiesterRequest.FirstName,
				NormalizedUserName = regiesterRequest.FirstName.ToUpper(),
				Email = regiesterRequest.Email,
				Gender = regiesterRequest.Gender,
				EmailConfirmed = true,
				PhoneNumberConfirmed = true
			};
			var result = await _userManager.CreateAsync(userModel, regiesterRequest.Password);
			if (result.Succeeded)
			{
				await _userManager.AddToRoleAsync(userModel, Roles.Basic.ToString());
				return new ApiResponse<Guid>(userModel.Id, "User Registered Successfully");
			}
			else
			{
				throw new ApiException(result.Errors.ToString());
			}
			
		}
    }
}
