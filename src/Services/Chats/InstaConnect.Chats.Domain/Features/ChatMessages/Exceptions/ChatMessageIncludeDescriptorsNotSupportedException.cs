using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageIncludeDescriptorsNotSupportedException : BadRequestException
{
    public ChatMessageIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors)
        : base(ChatMessageExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public ChatMessageIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
