using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Abstractions;

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Helpers;

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
		if (exception is not BaseException)
		{
			return false;
		}

		var problemDetails = _problemDetailsFactory.Create(exception);
		await _problemDetailsService.WriteAsync(httpContext, exception, problemDetails, cancellationToken);

		return true;
	}
}
