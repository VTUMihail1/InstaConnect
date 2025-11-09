using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Exceptions;

public class UnauthorizedException : BaseException
{
    protected UnauthorizedException(string message) : base(message, ExceptionStatus.Unauthorized)
    {
    }

    protected UnauthorizedException(string message, Exception exception) : base(message, exception, ExceptionStatus.Unauthorized)
    {
    }
}
