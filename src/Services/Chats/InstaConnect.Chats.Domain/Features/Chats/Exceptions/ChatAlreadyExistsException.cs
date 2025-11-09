using InstaConnect.Common.Domain.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatAlreadyExistsException : NotFoundException
{
    public ChatAlreadyExistsException(string participantOneId, string participantTwoId)
        : base(ChatExceptionErrorMessages.GetAlreadyExistsMessage(participantOneId, participantTwoId))
    {
    }

    public ChatAlreadyExistsException(string participantOneId, string participantTwoId, Exception exception)
        : base(ChatExceptionErrorMessages.GetAlreadyExistsMessage(participantOneId, participantTwoId), exception)
    {
    }
}
