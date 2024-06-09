using Food.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Interface
{
    public interface IApplicationDbContext
    {
		DbSet<Product> Products { get; set; }
		Task<int> SaveChangesAsync();
	}
}
