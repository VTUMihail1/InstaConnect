using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Presentation.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.ExceptionHandlers.Statuses;

internal class UnauthorizedExceptionStatus : IBaseExceptionStatus
{
    public BaseExceptionStatus Status => BaseExceptionStatus.Unauthorized;

    public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
    {
        var applicationProblemDetails = new ApplicationProblemDetails
        {
            Title = Status.ToString(),
            Type = exception.GetType().Name,
            Status = StatusCodes.Status401Unauthorized,
            Detail = exception.Message,
        };

        return applicationProblemDetails;
    }
}
