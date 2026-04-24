using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatIncludeDescriptorsNotSupportedException : BadRequestException
{
    public ChatIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors)
        : base(ChatExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors))
    {
    }

    public ChatIncludeDescriptorsNotSupportedException(ICollection<ChatsIncludeDescriptor> includeDescriptors, Exception exception)
        : base(ChatExceptionErrorMessages.GetIncludeDescriptorsNotSupportedMessage(includeDescriptors), exception)
    {
    }
}
