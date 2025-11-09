using InstaConnect.Common.Domain.Models;
using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.ExceptionHandlers.Statuses;

internal class NotFoundExceptionStatus : IExceptionStatus
{
    public ExceptionStatus ExceptionStatus => ExceptionStatus.NotFound;

    public ProblemDetails GetProblemDetails(Exception exception)
    {
        var problemDetails = new ProblemDetails()
        {
            Status = StatusCodes.Status404NotFound,
            Title = nameof(ExceptionStatus),
            Type = exception.GetType().Name,
            Detail = exception.Message,
        };

        return problemDetails;
    }
}
