namespace InstaConnect.Shared.Common.Exceptions.Base;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message, InstaConnectStatusCode.NotFound)
    {
    }

    public NotFoundException(string message, Exception exception) : base(message, exception, InstaConnectStatusCode.NotFound)
    {
    }
}
