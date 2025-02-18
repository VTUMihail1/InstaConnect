namespace InstaConnect.Shared.Common.Exceptions.Base;
public class AppValidationException : BadRequestException
{
    public AppValidationException(string message) : base(message)
    {
    }

    public AppValidationException(string message, Exception exception) : base(message, exception)
    {
    }
}
