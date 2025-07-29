using InstaConnect.Common.Exceptions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.Common.Infrastructure.Exceptions;

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
