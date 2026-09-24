using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;
using InstaConnect.Common.Domain.Features.Exceptions.Models;
using InstaConnect.Common.Presentation.Features.Exceptions.Models;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Abstractions;

public interface IBaseExceptionStatus
{
	public BaseExceptionStatus Status { get; }

	public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception);
}
