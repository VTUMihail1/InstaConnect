namespace InstaConnect.Common.Exceptions;
public class InvalidValidationException : BadRequestException
{
    public InvalidValidationException(string message) : base(message)
    {
    }

    public InvalidValidationException(string message, Exception exception) : base(message, exception)
    {
    }
}
