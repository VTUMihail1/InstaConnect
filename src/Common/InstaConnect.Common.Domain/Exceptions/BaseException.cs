using InstaConnect.Common.Models.Enums;

namespace InstaConnect.Common.Exceptions;

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

public interface IApplicationException
{
    public string Message { get; }
    public ExceptionStatus Status { get; }
}
