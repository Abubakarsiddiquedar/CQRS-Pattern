using Food.Application.DTOs;
using Food.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Application.Interface
{
	public interface IAccountService
	{
		Task<ApiResponse<Guid>> RegisterUser(RegisterRequest regiesterRequest);
	}
}
