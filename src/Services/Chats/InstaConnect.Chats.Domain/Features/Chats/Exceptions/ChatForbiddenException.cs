using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatForbiddenException : NotFoundException
{
    public ChatForbiddenException(ChatId id, UserId participantId)
        : base(ChatExceptionErrorMessages.GetForbiddenMessage(id, participantId))
    {
    }

    public ChatForbiddenException(ChatId id, UserId participantId, Exception exception)
        : base(ChatExceptionErrorMessages.GetForbiddenMessage(id, participantId), exception)
    {
    }
}
