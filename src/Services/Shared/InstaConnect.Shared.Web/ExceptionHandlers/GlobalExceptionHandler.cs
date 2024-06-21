using InstaConnect.Shared.Business.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstaConnect.Shared.Web.ExceptionHandlers;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        if (exception is BaseException baseException)
        {
            await HandleBaseExceptionAsync(httpContext, baseException, cancellationToken);
        }
        else
        {
            await HandleExceptionAsync(httpContext, exception, cancellationToken);
        }

        return true;
    }

    private async Task HandleBaseExceptionAsync(
        HttpContext httpContext,
        BaseException baseException,
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        var validationProblemDetails = new ValidationProblemDetails()
        {
            Title = nameof(baseException),
            Type = baseException.GetType().Name,
            Status = httpContext.Response.StatusCode,
            Detail = baseException.Message
        };

        await httpContext.Response.WriteAsJsonAsync(validationProblemDetails, cancellationToken);
    }

    private async Task HandleExceptionAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        httpContext.Response.ContentType = "application/json";

        var validationProblemDetails = new ValidationProblemDetails()
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = "UnhandledException",
            Title = "Unhandled exception",
            Detail = exception.InnerException?.Message ?? exception.Message
        };

        await httpContext.Response.WriteAsJsonAsync(validationProblemDetails, cancellationToken);
    }
}
