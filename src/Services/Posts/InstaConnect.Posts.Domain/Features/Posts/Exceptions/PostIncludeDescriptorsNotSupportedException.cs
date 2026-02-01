using InstaConnect.Common.Domain.Exceptions;
using InstaConnect.Posts.Domain.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Posts.Exceptions;

public class PostIncludeDescriptorsNotSupportedException : BadRequestException
{
    public PostIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> includeDescriptors)
        : base(PostExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public PostIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> includeDescriptors, Exception exception)
        : base(PostExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
