using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace Demo.API.Middlewares
{
	public class ExceptionHandlerMiddleware
	{
		private readonly ILogger<ExceptionHandlerMiddleware> logger;
		private readonly RequestDelegate next;

		public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
		{
			this.logger = logger;
			this.next = next;
		}

		public async Task InvokeAsync(HttpContext httpContext)
		{
			try
			{
				await next(httpContext);
			}
			catch (Exception ex)
			{
				//Unique Identifier
				var errorId = Guid.NewGuid();
				//Log This Exception
				logger.LogError(ex, $"{errorId} : {ex.Message}");
				//Return A Custom Error Response
				httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				httpContext.Response.ContentType = "application/json";
				var error = new
				{
					Id = errorId,
					ErrorMessage = "Something went wrong! We are looking into resolving this."
				};
				var jsonResponse = JsonSerializer.Serialize(error);
				await httpContext.Response.WriteAsync(jsonResponse);
			}
		}
	}
}
