using InstaConnect.Common.Presentation.Features.Exceptions.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Abstractions;

public interface IApplicationProblemDetailsService
{
	public Task WriteAsync(
		HttpContext httpContext,
		Exception exception,
		ApplicationProblemDetails details,
		CancellationToken cancellationToken);
}
