using InstaConnect.Common.Exceptions.Base;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Presentation.API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BaseException ex)
            {
                _logger.LogError(ex, ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)ex.StatusCode;

                await context.Response.WriteAsJsonAsync(new ValidationProblemDetails()
                {
                    Detail = ex.Message,
                    Status = context.Response.StatusCode,
                });
            }
        }
    }
}