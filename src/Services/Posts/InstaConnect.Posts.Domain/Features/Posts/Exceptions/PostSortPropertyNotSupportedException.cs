using InstaConnect.Common.Exceptions;
using InstaConnect.Posts.Common.Features.Posts.Utilities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

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
