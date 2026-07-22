using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessageId response)
	{
		public bool Matches(
			ChatMessage chatMessage,
			AddChatMessageCommand command)
		{
			return response.Matches(chatMessage.Id);
		}

		public bool Matches(
			ChatMessage chatMessage,
			UpdateChatMessageCommand command)
		{
			return response.Matches(chatMessage.Id);
		}
	}

	extension(ChatInclude p)
	{
		public bool Matches(AddChatMessageCommand command, ChatInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(ChatMessageInclude p)
	{
		public bool Matches(UpdateChatMessageCommand command, ChatMessageInclude include)
		{
			return p.Matches(include);
		}

		public bool Matches(DeleteChatMessageCommand command, ChatMessageInclude include)
		{
			return p.Matches(include);
		}
	}

	extension(ChatMessageAddedNotificationRequest request)
	{
		public bool Matches(AddChatMessageCommand command, ChatMessage entity)
		{
			return command.Id.Matches(request.ChatMessage.ParticipantOneId, request.ChatMessage.ParticipantTwoId) &&
				   entity.Sender != null && entity.Sender.Matches(request.ChatMessage.Sender) &&
				   entity.Chat != null && entity.Chat.Matches(request.ChatMessage.Chat) &&
				   command.Content == request.ChatMessage.Content &&
				   entity.CreatedAtUtc == request.ChatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.ChatMessage.UpdatedAtUtc;
		}
	}

	extension(ChatMessageUpdatedNotificationRequest request)
	{
		public bool Matches(UpdateChatMessageCommand command, ChatMessage entity)
		{
			return command.Id.Matches(request.ChatMessage.ParticipantOneId, request.ChatMessage.ParticipantTwoId, request.ChatMessage.MessageId) &&
				   entity.Sender != null && entity.Sender.Matches(request.ChatMessage.Sender) &&
				   entity.Chat != null && entity.Chat.Matches(request.ChatMessage.Chat) &&
				   command.Content == request.ChatMessage.Content &&
				   entity.CreatedAtUtc == request.ChatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.ChatMessage.UpdatedAtUtc;
		}
	}

	extension(ChatMessageDeletedNotificationRequest request)
	{
		public bool Matches(DeleteChatMessageCommand command, ChatMessage entity)
		{
			return entity.Id.Matches(command.Id) &&
				   entity.Sender != null && entity.Sender.Matches(request.ChatMessage.Sender) &&
				   entity.Chat != null && entity.Chat.Matches(request.ChatMessage.Chat) &&
				   entity.Content == request.ChatMessage.Content &&
				   entity.CreatedAtUtc == request.ChatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == request.ChatMessage.UpdatedAtUtc;
		}
	}

	extension(ChatMessage chatMessage)
	{
		public bool Matches(AddChatMessageCommand command)
		{
			return chatMessage.Id.Id.Matches(command.Id) &&
				   chatMessage.Content == command.Content;
		}

		public bool Matches(UpdateChatMessageCommand command)
		{
			return chatMessage.Id.Matches(command.Id) &&
				   chatMessage.Content == command.Content;
		}

		public bool Matches(DeleteChatMessageCommand command)
		{
			return chatMessage.Id.Matches(command.Id);
		}

		public bool MatchesInverted(AddChatMessageCommand command)
		{
			return chatMessage.Id.Id.Matches(command.Id.ParticipantTwoId.Id, command.Id.ParticipantOneId.Id) &&
				   chatMessage.Content == command.Content;
		}

		public bool MatchesInverted(UpdateChatMessageCommand command)
		{
			return chatMessage.Id.Id.Matches(command.Id.Id.ParticipantTwoId.Id, command.Id.Id.ParticipantOneId.Id) &&
				   chatMessage.Id.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   chatMessage.Content == command.Content;
		}

		public bool MatchesFilter(GetAllChatMessagesQuery query)
		{
			return (chatMessage.Id.Id.ParticipantOneId.Matches(query.CurrentUser.Id) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(query.Filter.Id.ParticipantTwoId)) ||
				   (chatMessage.Id.Id.ParticipantOneId.Matches(query.Filter.Id.ParticipantTwoId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(query.CurrentUser.Id));
		}
	}

	extension(ChatMessageResponse? response)
	{
		public bool MatchesFull<T>(ChatMessage? chatMessage, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFull(chatMessage.Chat, request);
		}

		public bool MatchesFullInverted<T>(ChatMessage? chatMessage, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Id.Matches(response.Id.Id.ParticipantTwoId.Id, response.Id.Id.ParticipantOneId.Id) &&
				   chatMessage.Id.MessageId.EqualsOrdinalIgnoreCase(response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFullInverted(chatMessage.Chat, request);
		}

		public bool MatchesWithoutChat<T>(ChatMessage? chatMessage, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool MatchesWithoutChatInverted<T>(ChatMessage? chatMessage, T request)
			where T : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Id.Matches(response.Id.Id.ParticipantTwoId.Id, response.Id.Id.ParticipantOneId.Id) &&
				   chatMessage.Id.MessageId.EqualsOrdinalIgnoreCase(response.Id.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool Matches(ChatMessage chatMessage, GetChatMessageByIdQuery query)
		{
			return response.MatchesFull(chatMessage, query);
		}

		public bool MatchesInverted(ChatMessage chatMessage, GetChatMessageByIdQuery query)
		{
			return response.MatchesFullInverted(chatMessage, query);
		}
	}

	extension(ChatMessageCollectionResponse response)
	{
		public bool MatchesWithoutSender<T>(
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(chat, request) &&
				   response.ChatMessages.MatchesCollection(request.Pagination,
														   chatMessages,
														   response => response.Id,
														   chatMessage => chatMessage.Id,
														   matches,
														   matchesFilter);
		}

		public bool MatchesWithoutSender<T>(
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			T request,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(chat, request) &&
				   response.ChatMessages.MatchesSortedCollection(request.Pagination,
																 chatMessages,
																 matches,
																 termTransformer,
																 matchesFilter);
		}

		public bool MatchesWithoutSenderInverted<T>(
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			T request)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(chat, request) &&
				   response.ChatMessages.MatchesCollection(request.Pagination,
														   chatMessages,
														   response => new(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId),
														   chatMessage => chatMessage.Id,
														   matches,
														   matchesFilter);
		}

		public bool MatchesWithoutSenderInverted<T>(
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			T request,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
			where T : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(chat, request) &&
				   response.ChatMessages.MatchesSortedCollection(request.Pagination,
																 chatMessages,
																 matches,
																 termTransformer,
																 matchesFilter);
		}

		public bool Matches(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query)
		{
			return response.MatchesWithoutSender(
					   (response, chatMessage) => response.MatchesWithoutChat(chatMessage, query),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   query);
		}

		public bool Matches(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSender(
					   (response, chatMessage) => response.MatchesWithoutChat(chatMessage, query),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   query,
					   termTransformer);
		}

		public bool MatchesInverted(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query)
		{
			return response.MatchesWithoutSenderInverted(
					   (response, chatMessage) => response.MatchesWithoutChatInverted(chatMessage, query),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   query);
		}

		public bool MatchesInverted(
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			GetAllChatMessagesQuery query,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSenderInverted(
					   (response, chatMessage) => response.MatchesWithoutChatInverted(chatMessage, query),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   query,
					   termTransformer);
		}
	}
}
