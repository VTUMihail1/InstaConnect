using InstaConnect.Common.Exceptions;
using InstaConnect.ChatMessages.Common.Features.ChatMessages.Utilities;

namespace InstaConnect.ChatMessages.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageNotFoundException : NotFoundException
{
    public ChatMessageNotFoundException(string participantOneId, string participantTwoId, string messageId)
        : base(ChatMessageExceptionErrorMessages.GetNotFoundMessage(participantOneId, participantTwoId, messageId))
    {
    }

    public ChatMessageNotFoundException(string participantOneId, string participantTwoId, string messageId, Exception exception)
        : base(ChatMessageExceptionErrorMessages.GetNotFoundMessage(participantOneId, participantTwoId, messageId), exception)
    {
    }
}
