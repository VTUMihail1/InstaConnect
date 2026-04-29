using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Abstractions;

public interface IApplicationProblemDetailsService
{
	public Task WriteAsync(
		HttpContext httpContext,
		Exception exception,
		ApplicationProblemDetails details,
		CancellationToken cancellationToken);
}
