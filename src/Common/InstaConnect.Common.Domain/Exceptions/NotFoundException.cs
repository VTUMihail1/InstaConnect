using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message, ExceptionStatus.NotFound)
    {
    }

    public NotFoundException(string message, Exception exception) : base(message, exception, ExceptionStatus.NotFound)
    {
    }
}
