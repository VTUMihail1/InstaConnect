using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Assertions;

public static class ChatMatchAssertions
{
	extension(ChatId response)
	{
		public void ShouldSatisfy(Chat chat, AddChatCommand command)
		{
			response.ShouldSatisfy(p => p.Matches(chat, command));
		}
	}

	extension(ChatResponse response)
	{
		public void ShouldSatisfy(Chat chat, GetChatByIdQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(chat, query));
		}

		public void ShouldSatisfyInverted(Chat chat, GetChatByIdQuery query)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(chat, query));
		}
	}

	extension(ChatCollectionResponse response)
	{
		public void ShouldSatisfy(
			User participantOne,
			ICollection<Chat> chats,
			GetAllChatsQuery query)
		{
			response.ShouldSatisfy(p => p.Matches(participantOne, chats, query));
		}

		public void ShouldSatisfy(
			User participantOne,
			ICollection<Chat> chats,
			GetAllChatsQuery query,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.Matches(participantOne, chats, query, termTransformer));
		}

		public void ShouldSatisfyInverted(
			User participantTwo,
			ICollection<Chat> chats,
			GetAllChatsQuery query)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(participantTwo, chats, query));
		}

		public void ShouldSatisfyInverted(
			User participantTwo,
			ICollection<Chat> chats,
			GetAllChatsQuery query,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			response.ShouldSatisfy(p => p.MatchesInverted(participantTwo, chats, query, termTransformer));
		}
	}

	extension(Chat chat)
	{
		public void ShouldSatisfy(AddChatCommand command)
		{
			chat.ShouldSatisfy(p => p.Matches(command));
		}
	}
}
