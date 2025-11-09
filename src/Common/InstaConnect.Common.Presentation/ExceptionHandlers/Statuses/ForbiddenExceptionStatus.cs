using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.ExceptionHandlers.Statuses;

internal class ForbiddenExceptionStatus : IExceptionStatus
{
    public ExceptionStatus ExceptionStatus => ExceptionStatus.Forbidden;

    public ProblemDetails GetProblemDetails(Exception exception)
    {
        var problemDetails = new ProblemDetails()
        {
            Title = nameof(ExceptionStatus),
            Type = exception.GetType().Name,
            Status = StatusCodes.Status403Forbidden,
            Detail = exception.Message,
        };

        return problemDetails;
    }
}
