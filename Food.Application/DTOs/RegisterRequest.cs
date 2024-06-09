using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.DTOs
{
	public  class RegisterRequest
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string lastName { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[MinLength(6)]
		public string Password { get; set; }

		[Required]
		[MinLength(6)]
		public string ConfirmPassword { get; set; }
		
		public string Gender { get; set; }
		}
}
