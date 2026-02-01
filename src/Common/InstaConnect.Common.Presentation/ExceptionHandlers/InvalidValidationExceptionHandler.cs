using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.ExceptionHandlers;

public sealed class InvalidValidationExceptionHandler : IExceptionHandler
{
    private readonly IApplicationProblemDetailsFactory _applicationProblemDetailsFactory;
    private readonly IApplicationProblemDetailsService _applicationProblemDetailsService;

    public InvalidValidationExceptionHandler(
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
        var invalidValidationException = exception as InvalidValidationException;

        if (invalidValidationException == null)
        {
            return false;
        }

        var applicationProblemDetails = _applicationProblemDetailsFactory.Create(invalidValidationException);
        await _applicationProblemDetailsService.WriteAsync(httpContext, exception, applicationProblemDetails, cancellationToken);

        return true;
    }
}
