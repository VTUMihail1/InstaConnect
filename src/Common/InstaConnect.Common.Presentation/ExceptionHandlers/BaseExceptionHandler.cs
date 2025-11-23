using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Extensions;
using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.ExceptionHandlers;

public sealed class BaseExceptionHandler : IExceptionHandler
{
    private readonly IApplicationProblemDetailsFactory _applicationProblemDetailsFactory;
    private readonly IApplicationProblemDetailsService _applicationProblemDetailsService;

    public BaseExceptionHandler(
        IApplicationProblemDetailsFactory applicationProblemDetailsFactory,
        IApplicationProblemDetailsService applicationProblemDetailsService)
    {
        _applicationProblemDetailsFactory = applicationProblemDetailsFactory;
        _applicationProblemDetailsService = applicationProblemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var baseException = exception as BaseException;

        if (baseException.IsNull())
        {
            return false;
        }

        var applicationProblemDetails = _applicationProblemDetailsFactory.Create(baseException!);
        await _applicationProblemDetailsService.WriteAsync(httpContext, exception, applicationProblemDetails, cancellationToken);

        return true;
    }
}
