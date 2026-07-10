using InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Assertions;

public static class ChatMessageMatchAssertions
{
	extension(ChatMessageId response)
	{
		public void ShouldSatisfy(ChatMessage chatMessage, AddChatMessageCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(chatMessage, command));
		}

		public void ShouldSatisfy(ChatMessage chatMessage, UpdateChatMessageCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(chatMessage, command));
		}
	}

	extension(ChatMessageResponse response)
	{
		public void ShouldSatisfy(ChatMessage chatMessage, GetChatMessageByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(chatMessage, query));
		}

		public void ShouldSatisfyInverted(ChatMessage chatMessage, GetChatMessageByIdQuery query)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(chatMessage, query));
		}
	}

	extension(ChatMessageCollectionResponse response)
	{
		public void ShouldSatisfy(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(chat, chatMessages, query));
		}

		public void ShouldSatisfy(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(chat, chatMessages, query, termTransformer));
		}

		public void ShouldSatisfyInverted(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(chat, chatMessages, query));
		}

		public void ShouldSatisfyInverted(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(chat, chatMessages, query, termTransformer));
		}
	}

	extension(ChatMessage chatMessage)
	{
		public void ShouldSatisfy(AddChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfy(UpdateChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.Matches(command));
		}

		public void ShouldSatisfyInverted(AddChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(command));
		}

		public void ShouldSatisfyInverted(UpdateChatMessageCommand command)
		{
			chatMessage.ShouldSatisfy(p => p.MatchesInverted(command));
		}
	}
}
