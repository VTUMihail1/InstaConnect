using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostIncludeDescriptorsNotSupportedException : BadRequestException
{
    public PostIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> includeDescriptors)
        : base(PostExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public PostIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> includeDescriptors, Exception exception)
        : base(PostExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
