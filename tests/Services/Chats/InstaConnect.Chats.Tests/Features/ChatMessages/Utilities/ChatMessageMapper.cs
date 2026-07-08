using InstaConnect.Chats.Domain.Features.ChatMessages.Models.ValueObjects;
using InstaConnect.Chats.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(ChatMessage chatMessage)
	{
		public ChatMessageId ToId()
		{
			return chatMessage.Id;
		}

		public ChatMessage ToFull()
		{
			return new ChatMessage(chatMessage.Id,
					   chatMessage.SenderId,
					   chatMessage.Content,
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc)
				.AddSender(chatMessage.Sender?.ToFull())
				.AddChat(chatMessage.Chat?.ToFull());
		}

		public ChatMessage ToWithoutSender()
		{
			return new ChatMessage(chatMessage.Id,
					   chatMessage.SenderId,
					   chatMessage.Content,
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc)
				.AddChat(chatMessage.Chat?.ToFull());
		}

		public ChatMessage ToWithoutChat()
		{
			return new ChatMessage(chatMessage.Id,
					   chatMessage.SenderId,
					   chatMessage.Content,
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc)
				.AddSender(chatMessage.Sender?.ToFull());
		}
	}
}
