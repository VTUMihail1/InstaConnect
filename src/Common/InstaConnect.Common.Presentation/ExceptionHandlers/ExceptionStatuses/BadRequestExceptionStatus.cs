using InstaConnect.Common.Exceptions;
using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.ExceptionHandlers.ExceptionStatuses;

internal class BadRequestExceptionStatus : IExceptionStatus
{
    public ExceptionStatus ExceptionStatus => ExceptionStatus.BadRequest;

    public ProblemDetails GetProblemDetails(Exception exception)
    {
        var problemDetails = new ProblemDetails()
        {
            Title = nameof(ExceptionStatus),
            Type = exception.GetType().Name,
            Status = StatusCodes.Status400BadRequest,
            Detail = exception.Message,
        };

        return problemDetails;
    }
}
