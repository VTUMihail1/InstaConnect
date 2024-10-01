using InstaConnect.Shared.Common.Exceptions.Base;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InstaConnect.Shared.Web.ExceptionHandlers;

public sealed class AppExceptionHandler : IExceptionHandler
{
    private readonly ILogger<AppExceptionHandler> _logger;

    public AppExceptionHandler(ILogger<AppExceptionHandler> logger)
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
        var statusCode = (int)baseException.StatusCode;

        httpContext.Response.ContentType = "application/json";

        var validationProblemDetails = new ValidationProblemDetails()
        {
            Title = Enum.GetName(baseException.StatusCode),
            Type = baseException.GetType().Name,
            Status = statusCode,
            Detail = baseException.Message
        };

        httpContext.Response.StatusCode = statusCode;
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

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await httpContext.Response.WriteAsJsonAsync(validationProblemDetails, cancellationToken);
    }
}
