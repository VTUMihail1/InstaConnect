using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Models.Enums;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.ExceptionHandlers.ExceptionStatuses;

internal class UnauthorizedExceptionStatus : IExceptionStatus
{
    public ExceptionStatus ExceptionStatus => ExceptionStatus.Unauthorized;

    public ProblemDetails GetProblemDetails(Exception exception)
    {
        var problemDetails = new ProblemDetails()
        {
            Title = nameof(ExceptionStatus),
            Type = exception.GetType().Name,
            Status = StatusCodes.Status401Unauthorized,
            Detail = exception.Message,
        };

        return problemDetails;
    }
}
