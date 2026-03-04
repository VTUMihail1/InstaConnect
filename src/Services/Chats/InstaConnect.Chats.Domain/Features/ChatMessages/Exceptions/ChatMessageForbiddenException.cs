using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageForbiddenException : NotFoundException
{
    public ChatMessageForbiddenException(ChatMessageId id, UserId senderId)
        : base(ChatMessageExceptionErrorMessages.GetForbiddenMessage(id, senderId))
    {
    }

    public ChatMessageForbiddenException(ChatMessageId id, UserId senderId, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetForbiddenMessage(id, senderId), exception)
    {
    }
}
