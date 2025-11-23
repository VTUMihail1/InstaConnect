using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Common.Domain.Exceptions;

public class BadRequestException : BaseException
{
    public BadRequestException(string message) : base(message, BaseExceptionStatus.BadRequest)
    {
    }

    public BadRequestException(string message, Exception exception) : base(message, BaseExceptionStatus.BadRequest, exception)
    {
    }
}
