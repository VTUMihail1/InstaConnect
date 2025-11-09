using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeSortPropertyNotSupportedException : BadRequestException
{
    public PostLikeSortPropertyNotSupportedException(PostLikeSortProperty sortProperty)
        : base(PostLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public PostLikeSortPropertyNotSupportedException(PostLikeSortProperty sortProperty, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
