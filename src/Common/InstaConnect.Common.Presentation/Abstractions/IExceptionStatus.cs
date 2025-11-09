using InstaConnect.Common.Domain.Models;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Abstractions;

public interface IExceptionStatus
{
    public ExceptionStatus ExceptionStatus { get; }

    public ProblemDetails GetProblemDetails(Exception exception);
}
