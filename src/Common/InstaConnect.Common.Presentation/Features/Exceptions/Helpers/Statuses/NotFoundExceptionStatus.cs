using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;
using InstaConnect.Common.Domain.Features.Exceptions.Models;
using InstaConnect.Common.Presentation.Features.Exceptions.Abstractions;
using InstaConnect.Common.Presentation.Features.Exceptions.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Helpers.Statuses;

internal class NotFoundExceptionStatus : IBaseExceptionStatus
{
	public BaseExceptionStatus Status => BaseExceptionStatus.NotFound;

	public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
	{
		return new ApplicationProblemDetails
		{
			Title = Status.ToString(),
			Type = exception.GetType().Name,
			Status = StatusCodes.Status404NotFound,
			Detail = exception.Message,
		};
	}
}
