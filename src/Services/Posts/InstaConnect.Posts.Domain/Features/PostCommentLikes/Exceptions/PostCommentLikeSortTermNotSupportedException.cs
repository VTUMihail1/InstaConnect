using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeSortTermNotSupportedException : BadRequestException
{
    public PostCommentLikeSortTermNotSupportedException(PostCommentLikesSortTerm sortTerm)
        : base(PostCommentLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortTerm))
    {
    }

    public PostCommentLikeSortTermNotSupportedException(PostCommentLikesSortTerm sortTerm, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortTerm), exception)
    {
    }
}
