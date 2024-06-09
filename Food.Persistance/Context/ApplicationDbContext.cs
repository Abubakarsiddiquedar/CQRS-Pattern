using Food.Application.Interface;
using Food.Domain.Entities;
using Food.Persistance.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Food.Persistance.Context
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>,IApplicationDbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Product> Products { get; set;}
		public async Task<int> SaveChangesAsync()
		{
			
			return await base.SaveChangesAsync();
		}
	}
}
