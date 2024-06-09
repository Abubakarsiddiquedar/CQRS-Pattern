using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Persistance.IdentityModels
{
	public class ApplicationUser : IdentityUser<Guid>
	{
		public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

		public string Gender { get; set; } = string.Empty;
	}
}
