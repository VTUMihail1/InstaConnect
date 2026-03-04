using InstaConnect.Chats.Domain.Models.Requests;
using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageIncludeDescriptorsNotSupportedException : BadRequestException
{
    public ChatMessageIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors)
        : base(ChatMessageExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public ChatMessageIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetInclideDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
