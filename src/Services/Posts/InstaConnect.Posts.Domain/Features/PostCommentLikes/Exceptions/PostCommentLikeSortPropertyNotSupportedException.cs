using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeSortPropertyNotSupportedException : BadRequestException
{
    public PostCommentLikeSortPropertyNotSupportedException(PostCommentLikeSortProperty sortProperty)
        : base(PostCommentLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public PostCommentLikeSortPropertyNotSupportedException(PostCommentLikeSortProperty sortProperty, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
