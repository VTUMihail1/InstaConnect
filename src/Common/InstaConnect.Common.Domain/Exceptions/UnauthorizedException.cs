using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Exceptions;

public class UnauthorizedException : BaseException
{
    protected UnauthorizedException(string message) : base(message, ExceptionStatus.Unauthorized)
    {
    }

    protected UnauthorizedException(string message, Exception exception) : base(message, exception, ExceptionStatus.Unauthorized)
    {
    }
}
