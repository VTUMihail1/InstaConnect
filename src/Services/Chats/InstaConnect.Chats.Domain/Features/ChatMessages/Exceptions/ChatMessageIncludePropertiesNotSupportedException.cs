using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageIncludePropertiesNotSupportedException : BadRequestException
{
    public ChatMessageIncludePropertiesNotSupportedException(ICollection<ChatMessageIncludeProperty> includeProperties)
        : base(ChatMessageExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties))
    {
    }

    public ChatMessageIncludePropertiesNotSupportedException(ICollection<ChatMessageIncludeProperty> includeProperties, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetInclidePropertyNotSupportedMessage(includeProperties), exception)
    {
    }
}
