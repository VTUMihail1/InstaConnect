using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Exceptions;

public class ForbiddenException : BaseException
{
    public ForbiddenException(string message) : base(message, ExceptionStatus.Forbidden)
    {
    }

    public ForbiddenException(string message, Exception exception) : base(message, exception, ExceptionStatus.Forbidden)
    {
    }
}
