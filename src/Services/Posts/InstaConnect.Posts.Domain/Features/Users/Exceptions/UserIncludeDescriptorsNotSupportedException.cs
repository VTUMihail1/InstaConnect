using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;
using InstaConnect.Posts.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Exceptions;

public class UserIncludeDescriptorsNotSupportedException : BadRequestException
{
    public UserIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> descriptors)
        : base(UserExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors))
    {
    }

    public UserIncludeDescriptorsNotSupportedException(ICollection<PostsIncludeDescriptor> descriptors, Exception exception)
        : base(UserExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors), exception)
    {
    }
}
