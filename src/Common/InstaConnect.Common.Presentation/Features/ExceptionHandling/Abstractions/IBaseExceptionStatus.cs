using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Abstractions;

public interface IBaseExceptionStatus
{
    public BaseExceptionStatus Status { get; }

    public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception);
}
