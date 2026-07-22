using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Chats.Events.Features.Chats;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;

public static class ChatEquals
{
	extension(ChatId response)
	{
		public bool Matches(
			Chat chat,
			AddChatCommand command)
		{
			return response.Matches(chat.Id);
		}
	}

	extension(ChatAddedEventRequest request)
	{
		public bool Matches(AddChatCommand command, Chat entity)
		{
			return command.ParticipantOneId.Matches(request.Chat.ParticipantOneId) &&
				   command.ParticipantTwoId.Matches(request.Chat.ParticipantTwoId) &&
				   entity.ParticipantOne != null && entity.ParticipantOne.Matches(request.Chat.ParticipantOne) &&
				   entity.ParticipantTwo != null && entity.ParticipantTwo.Matches(request.Chat.ParticipantTwo) &&
				   entity.CreatedAtUtc == request.Chat.CreatedAtUtc;
		}
	}

	extension(Chat chat)
	{
		public bool Matches(AddChatCommand command)
		{
			return chat.Id.Matches(command.ParticipantOneId.Id, command.ParticipantTwoId.Id);
		}

		public bool MatchesFilter(ChatsFilterQuery filter)
		{
			return (chat.Id.ParticipantOneId.Matches(filter.ParticipantOneId) &&
				   chat.ParticipantTwo != null &&
				   chat.ParticipantTwo.Name.Value.StartsWithOrdinalIgnoreCase(filter.ParticipantTwoName.Value)) ||
				   (chat.Id.ParticipantTwoId.Matches(filter.ParticipantOneId) &&
				   chat.ParticipantOne != null &&
				   chat.ParticipantOne.Name.Value.StartsWithOrdinalIgnoreCase(filter.ParticipantTwoName.Value));
		}
	}

	extension(ChatResponse? response)
	{
		public bool MatchesFull<T>(Chat? chat, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantOneId.Id, response.Id.ParticipantTwoId.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantOne) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesFullInverted<T>(Chat? chat, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId.Id, response.Id.ParticipantOneId.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne.MatchesFull(chat.ParticipantTwo) &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool MatchesWithoutParticipantOne<T>(Chat? chat, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantOneId.Id, response.Id.ParticipantTwoId.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantTwo);
		}

		public bool MatchesWithoutParticipantOneInverted<T>(Chat? chat, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chat != null &&
				   chat.Id.Matches(response.Id.ParticipantTwoId.Id, response.Id.ParticipantOneId.Id) &&
				   chat.CreatedAtUtc == response.CreatedAtUtc &&
				   response.ParticipantOne == null &&
				   response.ParticipantTwo.MatchesFull(chat.ParticipantOne);
		}

		public bool Matches(Chat chat, GetChatByIdQuery query)
		{
			return response.MatchesFull(chat, query);
		}

		public bool MatchesInverted(Chat chat, GetChatByIdQuery query)
		{
			return response.MatchesFullInverted(chat, query);
		}
	}

	extension(ChatCollectionResponse response)
	{
		public bool MatchesWithoutParticipantTwo<T>(
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesCollection(request.Pagination,
													chats,
													response => response.Id,
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantTwo<T>(
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantOne,
			ICollection<Chat> chats,
			T request,
			ISortEnumTermTransformer<Chat> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantOne) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesSortedCollection(request.Pagination,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted<T>(
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantTwo) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesCollection(request.Pagination,
													chats,
													response => new(response.Id.ParticipantTwoId, response.Id.ParticipantOneId),
													chat => chat.Id,
													matches,
													matchesFilter);
		}

		public bool MatchesWithoutParticipantTwoInverted<T>(
			Func<ChatResponse, Chat, bool> matches,
			Func<Chat, bool> matchesFilter,
			User participantTwo,
			ICollection<Chat> chats,
			T request,
			ISortEnumTermTransformer<Chat> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatsPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chats.Count(matchesFilter)) &&
				   response.ParticipantOne.MatchesFull(participantTwo) &&
				   response.ParticipantTwo == null &&
				   response.Chats.MatchesSortedCollection(request.Pagination,
														  chats,
														  matches,
														  termTransformer,
														  matchesFilter);
		}

		public bool Matches(
			User participantOne,
			ICollection<Chat> chats,
			GetAllChatsQuery query)
		{
			return response.MatchesWithoutParticipantTwo(
					   (response, chat) => response.MatchesWithoutParticipantOne(chat, query),
					   chat => chat.MatchesFilter(query.Filter),
					   participantOne,
					   chats,
					   query);
		}

		public bool Matches(
			User participantOne,
			ICollection<Chat> chats,
			GetAllChatsQuery query,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesWithoutParticipantTwo(
					   (response, chat) => response.MatchesWithoutParticipantOne(chat, query),
					   chat => chat.MatchesFilter(query.Filter),
					   participantOne,
					   chats,
					   query,
					   termTransformer);
		}

		public bool MatchesInverted(
			User participantTwo,
			ICollection<Chat> chats,
			GetAllChatsQuery query)
		{
			return response.MatchesWithoutParticipantTwoInverted(
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(chat, query),
					   chat => chat.MatchesFilter(query.Filter),
					   participantTwo,
					   chats,
					   query);
		}

		public bool MatchesInverted(
			User participantTwo,
			ICollection<Chat> chats,
			GetAllChatsQuery query,
			ISortEnumTermTransformer<Chat> termTransformer)
		{
			return response.MatchesWithoutParticipantTwoInverted(
					   (response, chat) => response.MatchesWithoutParticipantOneInverted(chat, query),
					   chat => chat.MatchesFilter(query.Filter),
					   participantTwo,
					   chats,
					   query,
					   termTransformer);
		}
	}
}
