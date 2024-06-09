using Food.Application.Interface;
using Food.Persistance.Context;
using Food.Persistance.IdentityModels;
using Food.Persistance.Seeds;
using Food.Persistance.SharedServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Persistance
{
	public static class ServiceExtensions
	{
		public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
		{
			//register services
			services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
				));
			services.AddIdentityCore<ApplicationUser>()
				.AddRoles<ApplicationRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>();

			services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
			services.AddTransient<IAccountService, AccountService>();
			DefaultRoles.SeedRoleAsync(services.BuildServiceProvider()).Wait();
			DefaultUsers.SeedUsersAsync(services.BuildServiceProvider()).Wait();


		}
	}
}
