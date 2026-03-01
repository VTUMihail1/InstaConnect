using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostsSortTermNotSupportedException : BadRequestException
{
    public PostsSortTermNotSupportedException(PostsSortTerm sortTerm)
        : base(PostExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public PostsSortTermNotSupportedException(PostsSortTerm sortTerm, Exception exception)
        : base(PostExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
