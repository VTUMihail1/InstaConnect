using InstaConnect.Common.Domain.Features.ExceptionHandling.Models;

namespace InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

public class NotFoundException : BaseException
{
    public NotFoundException(string message) : base(message, BaseExceptionStatus.NotFound)
    {
    }

    public NotFoundException(string message, Exception exception) : base(message, BaseExceptionStatus.NotFound, exception)
    {
    }
}
