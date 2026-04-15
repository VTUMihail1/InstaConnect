using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.ExceptionHandlers;

public sealed class BaseExceptionHandler : IExceptionHandler
{
    private readonly IApplicationProblemDetailsFactory _problemDetailsFactory;
    private readonly IApplicationProblemDetailsService _problemDetailsService;

    public BaseExceptionHandler(
        IApplicationProblemDetailsFactory problemDetailsFactory,
        IApplicationProblemDetailsService problemDetailsService)
    {
        _problemDetailsFactory = problemDetailsFactory;
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var baseException = exception as BaseException;

        if (baseException == null)
        {
            return false;
        }

        var problemDetails = _problemDetailsFactory.Create(baseException);
        await _problemDetailsService.WriteAsync(httpContext, exception, problemDetails, cancellationToken);

        return true;
    }
}
