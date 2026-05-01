using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Abstractions;

public interface IApplicationProblemDetailsFactory
{
	public ApplicationProblemDetails Create(Exception exception);

	public ApplicationProblemDetails Create(BaseException exception);

	public ApplicationProblemDetails Create(InvalidValidationException exception);

}
