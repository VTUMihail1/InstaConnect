using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Presentation.Abstractions;
using InstaConnect.Common.Presentation.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.ExceptionHandlers.Statuses;

internal class NotFoundExceptionStatus : IBaseExceptionStatus
{
    public BaseExceptionStatus Status => BaseExceptionStatus.NotFound;

    public ApplicationProblemDetails GetApplicationProblemDetails(BaseException exception)
    {
        var applicationProblemDetails = new ApplicationProblemDetails
        {
            Title = Status.ToString(),
            Type = exception.GetType().Name,
            Status = StatusCodes.Status404NotFound,
            Detail = exception.Message,
        };

        return applicationProblemDetails;
    }
}
