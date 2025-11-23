using InstaConnect.Common.Presentation.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Abstractions;
public interface IApplicationProblemDetailsService
{
    Task WriteAsync(
        HttpContext httpContext,
        Exception exception,
        ApplicationProblemDetails details,
        CancellationToken cancellationToken);
}
