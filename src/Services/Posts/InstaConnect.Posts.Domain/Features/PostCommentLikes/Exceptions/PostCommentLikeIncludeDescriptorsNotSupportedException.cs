using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Exceptions;

public class PostCommentLikeIncludeDescriptorsNotSupportedException : BadRequestException
{
    public PostCommentLikeIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> descriptors)
        : base(PostCommentLikeExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors))
    {
    }

    public PostCommentLikeIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> descriptors, Exception exception)
        : base(PostCommentLikeExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors), exception)
    {
    }
}
