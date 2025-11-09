using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentIncludePropertiesNotSupportedException : BadRequestException
{
    public PostCommentIncludePropertiesNotSupportedException(ICollection<PostCommentIncludeProperty> includeProperties)
        : base(PostCommentExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public PostCommentIncludePropertiesNotSupportedException(ICollection<PostCommentIncludeProperty> includeProperties, Exception exception)
        : base(PostCommentExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
