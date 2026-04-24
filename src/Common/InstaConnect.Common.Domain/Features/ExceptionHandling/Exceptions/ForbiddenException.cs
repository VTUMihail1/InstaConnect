using InstaConnect.Common.Domain.Features.ExceptionHandling.Models;

namespace InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

public class ForbiddenException : BaseException
{
    public ForbiddenException(string message) : base(message, BaseExceptionStatus.Forbidden)
    {
    }

    public ForbiddenException(string message, Exception exception) : base(message, BaseExceptionStatus.Forbidden, exception)
    {
    }
}
