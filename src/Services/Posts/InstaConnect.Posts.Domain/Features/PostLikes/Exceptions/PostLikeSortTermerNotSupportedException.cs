using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeSortTermerNotSupportedException : BadRequestException
{
    public PostLikeSortTermerNotSupportedException(PostLikesSortTerm sortTerm)
        : base(PostLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public PostLikeSortTermerNotSupportedException(PostLikesSortTerm sortTerm, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
