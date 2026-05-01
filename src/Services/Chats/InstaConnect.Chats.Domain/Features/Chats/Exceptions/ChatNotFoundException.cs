using InstaConnect.Common.Domain.Features.ExceptionHandling.Exceptions;

namespace InstaConnect.Chats.Domain.Features.Chats.Exceptions;

public class ChatNotFoundException : NotFoundException
{
	public ChatNotFoundException(ChatId id)
		: base(ChatExceptionErrorMessages.GetNotFoundMessage(id))
	{
	}

	public ChatNotFoundException(ChatId id, Exception exception)
		: base(ChatExceptionErrorMessages.GetNotFoundMessage(id), exception)
	{
	}
}
