using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeIncludePropertiesNotSupportedException : BadRequestException
{
    public PostCommentLikeIncludePropertiesNotSupportedException(ICollection<PostCommentLikeIncludeProperty> includeProperties)
        : base(PostCommentLikeExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public PostCommentLikeIncludePropertiesNotSupportedException(ICollection<PostCommentLikeIncludeProperty> includeProperties, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
