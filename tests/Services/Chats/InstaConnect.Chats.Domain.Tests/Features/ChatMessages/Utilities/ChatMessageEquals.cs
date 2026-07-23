using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Common.Domain.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;
using InstaConnect.Chats.Domain.Features.Users.Models.Requests;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessageId response)
	{
		public bool Matches(
			AddChatMessageCommand command,
			ChatMessage chatMessage)
		{
			return response.Matches(chatMessage.Id);
		}

		public bool Matches(
			UpdateChatMessageCommand command,
			ChatMessage chatMessage)
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
			return request.ChatMessage.Matches(command, entity);
		}
	}

	extension(ChatMessageUpdatedNotificationRequest request)
	{
		public bool Matches(UpdateChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.Matches(command, entity);
		}
	}

	extension(ChatMessageDeletedNotificationRequest request)
	{
		public bool Matches(DeleteChatMessageCommand command, ChatMessage entity)
		{
			return request.ChatMessage.Matches(command, entity);
		}
	}

	extension(ChatMessageNotificationRequest request)
	{
		public bool Matches(AddChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.ParticipantTwoId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(entity.Id.MessageId) &&
				   request.Sender.Matches(command.Id.ParticipantOneId, entity.Sender) &&
				   request.Chat.Matches(command.Id.ParticipantOneId, command.Id.ParticipantTwoId, entity.Chat) &&
				   request.Content == command.Content &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(UpdateChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   request.Sender.Matches(command.Id.Id.ParticipantOneId, entity.Sender) &&
				   request.Chat.Matches(command.Id.Id.ParticipantOneId, command.Id.Id.ParticipantTwoId, entity.Chat) &&
				   request.Content == command.Content &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}

		public bool Matches(DeleteChatMessageCommand command, ChatMessage? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(command.Id.Id.ParticipantTwoId.Id) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(command.Id.MessageId) &&
				   request.Sender.Matches(command.Id.Id.ParticipantOneId, entity.Sender) &&
				   request.Chat.Matches(command.Id.Id.ParticipantOneId, command.Id.Id.ParticipantTwoId, entity.Chat) &&
				   request.Content == entity.Content &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
		}
	}

	extension(ChatNotificationRequest request)
	{
		public bool Matches(UserId participantOneId, UserId participantTwoId, Chat? entity)
		{
			return entity != null &&
				   request.ParticipantOneId.EqualsOrdinalIgnoreCase(participantOneId.Id) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(participantTwoId.Id) &&
				   request.ParticipantOne.Matches(participantOneId, entity.ParticipantOne) &&
				   request.ParticipantTwo.Matches(participantTwoId, entity.ParticipantTwo) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc;
		}
	}

	extension(UserNotificationRequest request)
	{
		public bool Matches(UserId id, User? entity)
		{
			return entity != null &&
				   request.Id.EqualsOrdinalIgnoreCase(id.Id) &&
				   request.Name.EqualsOrdinalIgnoreCase(entity.Name.Value) &&
				   request.Email.EqualsOrdinalIgnoreCase(entity.Email.Value) &&
				   request.FirstName == entity.FirstName &&
				   request.LastName == entity.LastName &&
				   (entity.ProfileImage == null || request.ProfileImageUrl.EqualsOrdinalIgnoreCase(entity.ProfileImage.Url)) &&
				   request.CreatedAtUtc == entity.CreatedAtUtc &&
				   request.UpdatedAtUtc == entity.UpdatedAtUtc;
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
		public bool MatchesFull<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.Id) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFull(request, chatMessage.Chat);
		}

		public bool MatchesFullInverted<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
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
				   response.Chat.MatchesFullInverted(request, chatMessage.Chat);
		}

		public bool MatchesWithoutChat<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
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

		public bool MatchesWithoutChatInverted<TQuery>(TQuery request, ChatMessage? chatMessage)
			where TQuery : ICurrentUserableQuery
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

		public bool Matches(GetChatMessageByIdQuery query, ChatMessage chatMessage)
		{
			return response.MatchesFull(query, chatMessage);
		}

		public bool MatchesInverted(GetChatMessageByIdQuery query, ChatMessage chatMessage)
		{
			return response.MatchesFullInverted(query, chatMessage);
		}
	}

	extension(ChatMessageCollectionResponse response)
	{
		public bool MatchesWithoutSender<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesCollection(request.Pagination,
														   chatMessages,
														   response => response.Id,
														   chatMessage => chatMessage.Id,
														   matches,
														   matchesFilter);
		}

		public bool MatchesWithoutSender<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(request.Pagination,
																 chatMessages,
																 matches,
																 termTransformer,
																 matchesFilter);
		}

		public bool MatchesWithoutSenderInverted<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesCollection(request.Pagination,
														   chatMessages,
														   response => new(new(response.Id.Id.ParticipantTwoId, response.Id.Id.ParticipantOneId), response.Id.MessageId),
														   chatMessage => chatMessage.Id,
														   matches,
														   matchesFilter);
		}

		public bool MatchesWithoutSenderInverted<TQuery>(
			TQuery request,
			Func<ChatMessageResponse, ChatMessage, bool> matches,
			Func<ChatMessage, bool> matchesFilter,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TQuery : ICurrentUserableQuery, IPaginatableQuery<ChatMessagesPaginationQuery>
		{
			return response.MatchesCollectionResponse(request.Pagination, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(request.Pagination,
																 chatMessages,
																 matches,
																 termTransformer,
																 matchesFilter);
		}

		public bool Matches(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesWithoutSender(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChat(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages);
		}

		public bool Matches(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSender(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChat(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   termTransformer);
		}

		public bool MatchesInverted(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages)
		{
			return response.MatchesWithoutSenderInverted(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChatInverted(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages);
		}

		public bool MatchesInverted(
			GetAllChatMessagesQuery query,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.MatchesWithoutSenderInverted(
					   query,
					   (response, chatMessage) => response.MatchesWithoutChatInverted(query, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(query),
					   chat,
					   chatMessages,
					   termTransformer);
		}
	}
}
