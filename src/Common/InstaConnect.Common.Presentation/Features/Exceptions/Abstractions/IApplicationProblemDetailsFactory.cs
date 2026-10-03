using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;
using InstaConnect.Common.Presentation.Features.Exceptions.Models;

namespace InstaConnect.Common.Presentation.Features.Exceptions.Abstractions;

public interface IApplicationProblemDetailsFactory
{
	public ApplicationProblemDetails Create(Exception exception);

	public ApplicationProblemDetails Create(BaseException exception);

	public ApplicationProblemDetails Create(InvalidValidationException exception);

}
