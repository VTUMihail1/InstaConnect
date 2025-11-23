using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Common.Presentation.Abstractions;
public interface IApplicationProblemDetailsFactory
{
    ApplicationProblemDetails Create(Exception exception);

    ApplicationProblemDetails Create(BaseException exception);

    ApplicationProblemDetails Create(InvalidValidationException exception);

}
