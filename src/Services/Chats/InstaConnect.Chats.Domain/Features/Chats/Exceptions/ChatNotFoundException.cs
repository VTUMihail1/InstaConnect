using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatNotFoundException : NotFoundException
{
    public ChatNotFoundException(string participantOneId, string participantTwoId)
        : base(ChatExceptionErrorMessages.GetNotFoundMessage(participantOneId, participantTwoId))
    {
    }

    public ChatNotFoundException(string participantOneId, string participantTwoId, Exception exception)
        : base(ChatExceptionErrorMessages.GetNotFoundMessage(participantOneId, participantTwoId), exception)
    {
    }
}
