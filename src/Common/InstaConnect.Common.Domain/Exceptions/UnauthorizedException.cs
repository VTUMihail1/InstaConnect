using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Exceptions;

public class UnauthorizedException : BaseException
{
    protected UnauthorizedException(string message) : base(message, BaseExceptionStatus.Unauthorized)
    {
    }

    protected UnauthorizedException(string message, Exception exception) : base(message, BaseExceptionStatus.Unauthorized, exception)
    {
    }
}
