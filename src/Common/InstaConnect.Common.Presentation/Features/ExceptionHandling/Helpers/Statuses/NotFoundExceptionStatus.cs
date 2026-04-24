using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Common.Domain.Features.ExceptionHandling.Models;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Abstractions;
using InstaConnect.Common.Presentation.Features.ExceptionHandling.Models;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Presentation.Features.ExceptionHandling.Helpers.Statuses;

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
