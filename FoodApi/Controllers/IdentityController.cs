using Food.Application.DTOs;
using Food.Application.Features.Products.Commands;
using Food.Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Food.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class IdentityController : ControllerBase
	{
		private readonly IAccountService _accountService;
        public IdentityController(IAccountService accountService)
        {
			_accountService = accountService; 
		}

		[HttpPost("RegisterUser")]
		public async Task<IActionResult> AddProducts(RegisterRequest registerRequest)
		{
			var result = await _accountService.RegisterUser(registerRequest);
			return Ok(result);
		}
	}
}
