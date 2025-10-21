using InstaConnect.Common.Exceptions;
using InstaConnect.PostLikes.Common.Features.PostLikes.Utilities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Exceptions;

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
