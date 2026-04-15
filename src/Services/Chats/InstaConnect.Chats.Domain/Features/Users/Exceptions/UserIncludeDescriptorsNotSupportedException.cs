using InstaConnect.Chats.Domain.Models.Requests;
using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Users.Exceptions;

public class UserIncludeDescriptorsNotSupportedException : BadRequestException
{
    public UserIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> descriptors)
        : base(UserExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors))
    {
    }

    public UserIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> descriptors, Exception exception)
        : base(UserExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(descriptors), exception)
    {
    }
}
