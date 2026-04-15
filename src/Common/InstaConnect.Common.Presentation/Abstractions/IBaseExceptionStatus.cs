using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Presentation.Models;

namespace InstaConnect.Common.Presentation.Abstractions;

public interface IBaseExceptionStatus
{
    public BaseExceptionStatus Status { get; }

    public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception);
}
