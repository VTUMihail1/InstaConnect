using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageSortPropertyNotSupportedException : BadRequestException
{
    public ChatMessageSortPropertyNotSupportedException(ChatMessageSortProperty sortProperty)
        : base(ChatMessageExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty))
    {
    }

    public ChatMessageSortPropertyNotSupportedException(ChatMessageSortProperty sortProperty, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetSortPropertyNotSupportedMessage(sortProperty), exception)
    {
    }
}
