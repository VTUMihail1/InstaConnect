using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Common.Presentation.Abstractions;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.ExceptionHandlers;

public class ProblemDetailsFactory : IProblemDetailsFactory
{
    private readonly IEnumerable<IExceptionStatus> _exceptionStatuses;

    public ProblemDetailsFactory(IEnumerable<IExceptionStatus> exceptionStatuses)
    {
        _exceptionStatuses = exceptionStatuses;
    }

    public ProblemDetails Create(Exception exception)
    {
        var baseException = exception as BaseException;

        if (baseException == null)
        {
            return CreateInternalServerError(exception);
        }

        var exceptionStatus = _exceptionStatuses.FirstOrDefault(a => a.ExceptionStatus == baseException.Status);

        if (exceptionStatus == null)
        {
            return CreateInternalServerError(exception);
        }

        return exceptionStatus.GetProblemDetails(exception);
    }

    private ProblemDetails CreateInternalServerError(Exception exception)
    {
        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = exception.GetType().Name,
            Title = exception.GetType().Name,
            Detail = exception.InnerException?.Message ?? exception.Message
        };

        return problemDetails;
    }
}
