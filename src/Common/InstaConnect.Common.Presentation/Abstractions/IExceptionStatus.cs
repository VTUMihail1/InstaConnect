using InstaConnect.Common.Exceptions;
using InstaConnect.Common.Models.Enums;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IExceptionStatus
{
    public ExceptionStatus ExceptionStatus { get; }

    public ProblemDetails GetProblemDetails(Exception exception);
}
