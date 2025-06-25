namespace InstaConnect.Common.Exceptions;

public class UnauthorizedException : BaseException
{
    protected UnauthorizedException(string message) : base(message, InstaConnectStatusCode.Unauthorized)
    {
    }

    protected UnauthorizedException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.Unauthorized)
    {
    }
}
