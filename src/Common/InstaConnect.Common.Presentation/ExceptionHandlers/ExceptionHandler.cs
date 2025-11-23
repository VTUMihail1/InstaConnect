using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.ExceptionHandlers;

public sealed class ExceptionHandler : IExceptionHandler
{
    private readonly IApplicationProblemDetailsFactory _applicationProblemDetailsFactory;
    private readonly IApplicationProblemDetailsService _applicationProblemDetailsService;

    public ExceptionHandler(
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
        var applicationProblemDetails = _applicationProblemDetailsFactory.Create(exception);
        await _applicationProblemDetailsService.WriteAsync(httpContext, exception, applicationProblemDetails, cancellationToken);

        return true;
    }
}
