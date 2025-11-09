using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostSortPropertyNotSupportedException : BadRequestException
{
    public PostSortPropertyNotSupportedException(PostSortProperty sortProperty)
        : base(PostExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public PostSortPropertyNotSupportedException(PostSortProperty sortProperty, Exception exception)
        : base(PostExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
