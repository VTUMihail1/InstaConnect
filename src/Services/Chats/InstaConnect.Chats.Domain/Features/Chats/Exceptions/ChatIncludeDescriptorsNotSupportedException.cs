using InstaConnect.Chats.Domain.Models.Requests;
using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatIncludeDescriptorsNotSupportedException : BadRequestException
{
    public ChatIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors)
        : base(ChatExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public ChatIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors, Exception exception)
        : base(ChatExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
