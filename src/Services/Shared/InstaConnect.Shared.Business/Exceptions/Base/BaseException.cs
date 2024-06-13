using InstaConnect.Shared.Business.Models.Enum;

namespace InstaConnect.Shared.Business.Exceptions.Base;

public class BaseException : Exception
{
    protected BaseException(string message, InstaConnectStatusCode statusCode) : base(message)
    {
        Message = message;
        StatusCode = statusCode;
    }

    protected BaseException(string message, Exception exception, InstaConnectStatusCode statusCode) : base(message, exception)
    {
        Message = message;
        StatusCode = statusCode;
    }

    public override string Message { get; }
    public InstaConnectStatusCode StatusCode { get; }
}
