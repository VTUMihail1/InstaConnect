using InstaConnect.Chats.Tests.Features.Chats.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageReference
{
	extension(ChatMessage? chatMessage)
	{
		public ChatMessage? SetSender()
		{
			chatMessage?.Sender?.AddChatMessage(chatMessage);

			return chatMessage;
		}

		public ChatMessage? SetChat()
		{
			chatMessage?.Chat?.AddChatMessage(chatMessage);
			chatMessage?.Chat?.SetParticipantOne().SetParticipantTwo();

			return chatMessage;
		}
	}
}
