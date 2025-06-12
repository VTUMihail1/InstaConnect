using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Common.Infrastructure.Exceptions;

public class PostSortPropertyNotSupportedException : BadRequestException
{
    private const string ErrorMessage = "Post sort property is not supported";

    public PostSortPropertyNotSupportedException() : base(ErrorMessage)
    {
    }

    public PostSortPropertyNotSupportedException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
