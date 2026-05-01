namespace InstaConnect.Chats.Domain.Features.ChatMessages.Helpers;

internal class ChatMessageFactory : IChatMessageFactory
{
	private readonly IGuidProvider _guidProvider;
	private readonly IDateTimeProvider _dateTimeProvider;

	public ChatMessageFactory(
		IGuidProvider guidProvider,
		IDateTimeProvider dateTimeProvider)
	{
		_guidProvider = guidProvider;
		_dateTimeProvider = dateTimeProvider;
	}

	public ChatMessage Create(ChatId id, UserId senderId, string content)
	{
		var messageId = _guidProvider.NewGuid().ToString();
		var utcNow = _dateTimeProvider.GetOffsetUtcNow();
		var chatMessage = new ChatMessage(
			new(id, messageId),
			senderId,
			content,
			utcNow,
			utcNow);

		return chatMessage;
	}
}
