using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentSortTermNotSupportedException : BadRequestException
{
    public PostCommentSortTermNotSupportedException(PostCommentsSortTerm sortTerm)
        : base(PostCommentExceptionErrorMessages.GetSortTermNotSupportedMessage(sortTerm))
    {
    }

    public PostCommentSortTermNotSupportedException(PostCommentsSortTerm sortProperty, Exception exception)
        : base(PostCommentExceptionErrorMessages.GetSortTermNotSupportedMessage(sortProperty), exception)
    {
    }
}
