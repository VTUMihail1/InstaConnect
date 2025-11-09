using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeIncludePropertiesNotSupportedException : BadRequestException
{
    public PostLikeIncludePropertiesNotSupportedException(ICollection<PostLikeIncludeProperty> includeProperties)
        : base(PostLikeExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public PostLikeIncludePropertiesNotSupportedException(ICollection<PostLikeIncludeProperty> includeProperties, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
