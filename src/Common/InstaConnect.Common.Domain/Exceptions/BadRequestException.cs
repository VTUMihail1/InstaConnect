namespace InstaConnect.Common.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string message) : base(message, InstaConnectStatusCode.BadRequest)
    {
    }

    public BadRequestException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.BadRequest)
    {
    }
}
