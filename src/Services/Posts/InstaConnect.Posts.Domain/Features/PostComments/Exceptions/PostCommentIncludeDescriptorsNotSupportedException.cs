using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.PostComments.Exceptions;

public class PostCommentIncludeDescriptorsNotSupportedException : BadRequestException
{
    public PostCommentIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> descriptors)
        : base(PostCommentExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(descriptors))
    {
    }

    public PostCommentIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> descriptors, Exception exception)
        : base(PostCommentExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(descriptors), exception)
    {
    }
}
