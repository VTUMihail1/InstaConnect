using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Exceptions;

public class BaseException : Exception
{
    protected BaseException(string message, ExceptionStatus status) : base(message)
    {
        Message = message;
        Status = status;
    }

    protected BaseException(string message, Exception exception, ExceptionStatus status) : base(message, exception)
    {
        Message = message;
        Status = status;
    }

    public override string Message { get; }
    public ExceptionStatus Status { get; }
}
