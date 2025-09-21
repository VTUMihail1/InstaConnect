using InstaConnect.Common.Exceptions;
using InstaConnect.Common.Models.Enums;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IExceptionStatus
{
    public ExceptionStatus ExceptionStatus { get; }

    public ProblemDetails GetProblemDetails(Exception exception);
}
