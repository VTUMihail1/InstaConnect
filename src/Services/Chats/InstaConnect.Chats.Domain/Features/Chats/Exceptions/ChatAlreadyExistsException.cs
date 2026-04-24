using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatAlreadyExistsException : NotFoundException
{
    public ChatAlreadyExistsException(ChatId id)
        : base(ChatExceptionErrorMessages.GetAlreadyExistsMessage(id))
    {
    }

    public ChatAlreadyExistsException(ChatId id, Exception exception)
        : base(ChatExceptionErrorMessages.GetAlreadyExistsMessage(id), exception)
    {
    }
}
