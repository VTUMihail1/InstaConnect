using InstaConnect.Shared.Common.Models.Enums;

namespace InstaConnect.Shared.Common.Exceptions.Base;

public class UnauthorizedException : BaseException
{
    protected UnauthorizedException(string message) : base(message, InstaConnectStatusCode.Unauthorized)
    {
    }

    protected UnauthorizedException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.Unauthorized)
    {
    }
}
