using InstaConnect.Common.Domain.Features.Exceptions.Exceptions;

namespace InstaConnect.Chats.Domain.Features.ChatMessages.Exceptions;

public class ChatMessageNotFoundException : NotFoundException
{
	public ChatMessageNotFoundException(ChatMessageId id)
		: base(ChatMessageExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}

	public ChatMessageNotFoundException(ChatMessageId id, Exception exception)
		: base(ChatMessageExceptionErrorMessages.GetNotFoundMessage(id), exception)
	{
	}
}
