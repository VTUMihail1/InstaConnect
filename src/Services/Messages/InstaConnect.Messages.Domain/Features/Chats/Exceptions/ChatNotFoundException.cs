using InstaConnect.Common.Exceptions;
using InstaConnect.Chats.Common.Features.Chats.Utilities;

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
