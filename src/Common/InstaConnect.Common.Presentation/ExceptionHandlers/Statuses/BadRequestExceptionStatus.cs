using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Presentation.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.ExceptionHandlers.Statuses;

internal class BadRequestExceptionStatus : IBaseExceptionStatus
{
    public BaseExceptionStatus Status => BaseExceptionStatus.BadRequest;

    public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
    {
        return new ApplicationProblemDetails
        {
            Title = Status.ToString(),
            Type = exception.GetType().Name,
            Status = StatusCodes.Status400BadRequest,
            Detail = exception.Message,
        };
    }
}
