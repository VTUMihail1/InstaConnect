using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Exceptions;

public class ForbiddenException : BaseException
{
    public ForbiddenException(string message) : base(message, ExceptionStatus.Forbidden)
    {
    }

    public ForbiddenException(string message, Exception exception) : base(message, exception, ExceptionStatus.Forbidden)
    {
    }
}
