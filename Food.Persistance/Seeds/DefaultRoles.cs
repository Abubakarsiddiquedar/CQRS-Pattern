using Food.Application.Enums;
using Food.Persistance.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Persistance.Seeds
{
	public static class DefaultRoles
	{
		public static async Task SeedRoleAsync(IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

			var Admin = new ApplicationRole();
			Admin.Name = Roles.Admin.ToString();
			Admin.NormalizedName = Roles.Admin.ToString().ToUpper();
			await roleManager.CreateAsync(Admin);

			var SuperAdmin = new ApplicationRole();
			SuperAdmin.Name = Roles.SuperAdmin.ToString();
			SuperAdmin.NormalizedName = Roles.SuperAdmin.ToString().ToUpper();
			await roleManager.CreateAsync(SuperAdmin);

			var basic = new ApplicationRole();
			basic.Name = Roles.Basic.ToString();
			basic.NormalizedName = Roles.Basic.ToString().ToUpper();
			await roleManager.CreateAsync(basic);
		}
	}
}
