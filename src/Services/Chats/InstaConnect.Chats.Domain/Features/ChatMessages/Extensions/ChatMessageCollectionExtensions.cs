namespace InstaConnect.Chats.Domain.Features.ChatMessages.Extensions;

public static class ChatMessageCollectionExtensions
{
	extension(ICollection<ChatMessage> chatMessages)
	{
		public ICollection<ChatMessage> AddChat(Chat chat)
		{
			foreach (var chatMessage in chatMessages)
			{
				chatMessage.AddChat(chat);
			}

			return chatMessages;
		}

		public ICollection<ChatMessage> AddSender(User sender)
		{
			foreach (var chatMessage in chatMessages)
			{
				chatMessage.AddSender(sender);
			}

			return chatMessages;
		}
	}
}
