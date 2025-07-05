using System.Net.Mime;

using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.ExceptionHandlers;

public sealed class ApplicationExceptionHandler : IExceptionHandler
{
    private readonly IProblemDetailsFactory _problemDetailsFactory;
    private readonly IProblemDetailsService _problemDetailsService;

    public ApplicationExceptionHandler(
        IProblemDetailsFactory problemDetailsFactory,
        IProblemDetailsService problemDetailsService)
    {
        _problemDetailsFactory = problemDetailsFactory;
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = _problemDetailsFactory.Create(exception);

        httpContext.Response.ContentType = MediaTypeNames.Application.Json;
        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;

        var problemDetailsContext = new ProblemDetailsContext
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails = problemDetails,
        };

        await _problemDetailsService.WriteAsync(problemDetailsContext);

        return true;
    }
}
