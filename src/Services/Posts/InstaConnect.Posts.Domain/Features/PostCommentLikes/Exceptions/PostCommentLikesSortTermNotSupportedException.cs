using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikesSortTermNotSupportedException : BadRequestException
{
    public PostCommentLikesSortTermNotSupportedException(PostCommentLikesSortTerm sortTerm)
        : base(PostCommentLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public PostCommentLikesSortTermNotSupportedException(PostCommentLikesSortTerm sortTerm, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
