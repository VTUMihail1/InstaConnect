using InstaConnect.Common.Exceptions;
using InstaConnect.PostCommentLikes.Common.Features.PostCommentLikes.Utilities;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Exceptions;

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
