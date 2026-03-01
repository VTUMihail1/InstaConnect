using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikesForUserSortTermNotSupportedException : BadRequestException
{
    public PostCommentLikesForUserSortTermNotSupportedException(PostCommentLikesForUserSortTerm sortTerm)
        : base(PostCommentLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortTerm))
    {
    }

    public PostCommentLikesForUserSortTermNotSupportedException(PostCommentLikesForUserSortTerm sortTerm, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortTerm), exception)
    {
    }
}
