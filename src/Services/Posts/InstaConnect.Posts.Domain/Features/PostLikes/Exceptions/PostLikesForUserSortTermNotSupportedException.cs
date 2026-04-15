using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikesForUserSortTermNotSupportedException : BadRequestException
{
    public PostLikesForUserSortTermNotSupportedException(PostLikesForUserSortTerm sortTerm)
        : base(PostLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public PostLikesForUserSortTermNotSupportedException(PostLikesForUserSortTerm sortTerm, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
