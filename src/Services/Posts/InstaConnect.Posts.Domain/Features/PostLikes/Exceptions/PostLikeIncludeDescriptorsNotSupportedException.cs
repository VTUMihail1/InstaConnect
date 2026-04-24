using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Exceptions;

public class PostLikeIncludeDescriptorsNotSupportedException : BadRequestException
{
    public PostLikeIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> descriptors)
        : base(PostLikeExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors))
    {
    }

    public PostLikeIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> includeProperties, Exception exception)
        : base(PostLikeExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeProperties), exception)
    {
    }
}
