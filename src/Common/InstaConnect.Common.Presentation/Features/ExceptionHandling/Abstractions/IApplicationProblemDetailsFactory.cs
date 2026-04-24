using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Abstractions;

public interface IApplicationProblemDetailsFactory
{
    ApplicationProblemDetails Create(Exception exception);

    ApplicationProblemDetails Create(BaseException exception);

    ApplicationProblemDetails Create(InvalidValidationException exception);

}
