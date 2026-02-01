using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostsSortTermerNotSupportedException : BadRequestException
{
    public PostsSortTermerNotSupportedException(PostsSortTerm sortTerm)
        : base(PostExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public PostsSortTermerNotSupportedException(PostsSortTerm sortTerm, Exception exception)
        : base(PostExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm), exception)
    {
    }
}
