using Food.Application.Exceptions;
using Food.Application.Wrapper;
using System.Net;
using System.Text.Json;

namespace Food.Api.Middlewares
{
	public class ErrorHandlerMiddleware
	{
		private readonly RequestDelegate _next;

		public ErrorHandlerMiddleware(RequestDelegate next) 
		{ 
			_next = next;
		}
		
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				var response = context.Response;
				response.ContentType = "application/json";
				var responseModel = new ApiResponse<string> { Successed = false, Message = ex.Message }; 
				switch (ex)
				{
					case ApiException e:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						break;
					case ValidtionErrorException e:
						response.StatusCode = (int)HttpStatusCode.BadRequest;
						responseModel.Error = e.Errors;
						break;
					default:
						response.StatusCode = (int)HttpStatusCode.InternalServerError;
						break;
				}
				var result = JsonSerializer.Serialize(responseModel);
				await response.WriteAsync(result);
			}
		}

	}
}
