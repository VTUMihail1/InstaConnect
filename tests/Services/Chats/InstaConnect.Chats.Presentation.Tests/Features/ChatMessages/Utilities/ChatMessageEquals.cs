using InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Common.Domain.Features.Common.Extensions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;
using InstaConnect.Common.Tests.Features.DataAttributes.Enums.Sort;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageEquals
{
	extension(ChatMessageAddedNotificationRequest r)
	{
		public bool Matches(AddChatMessageApiRequest request, ChatMessage entity)
		{
			return request.ParticipantOneId.EqualsOrdinalIgnoreCase(r.ChatMessage.ParticipantOneId) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(r.ChatMessage.ParticipantTwoId) &&
				   entity.Sender != null && entity.Sender.Matches(r.ChatMessage.Sender) &&
				   entity.Chat != null && entity.Chat.Matches(r.ChatMessage.Chat) &&
				   request.Body.Content == r.ChatMessage.Content &&
				   entity.CreatedAtUtc == r.ChatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.ChatMessage.UpdatedAtUtc;
		}
	}

	extension(ChatMessageUpdatedNotificationRequest r)
	{
		public bool Matches(UpdateChatMessageApiRequest request, ChatMessage entity)
		{
			return request.ParticipantOneId.EqualsOrdinalIgnoreCase(r.ChatMessage.ParticipantOneId) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(r.ChatMessage.ParticipantTwoId) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(r.ChatMessage.MessageId) &&
				   entity.Sender != null && entity.Sender.Matches(r.ChatMessage.Sender) &&
				   entity.Chat != null && entity.Chat.Matches(r.ChatMessage.Chat) &&
				   request.Body.Content == r.ChatMessage.Content &&
				   entity.CreatedAtUtc == r.ChatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.ChatMessage.UpdatedAtUtc;
		}
	}

	extension(ChatMessageDeletedNotificationRequest r)
	{
		public bool Matches(DeleteChatMessageApiRequest request, ChatMessage entity)
		{
			return request.ParticipantOneId.EqualsOrdinalIgnoreCase(r.ChatMessage.ParticipantOneId) &&
				   request.ParticipantTwoId.EqualsOrdinalIgnoreCase(r.ChatMessage.ParticipantTwoId) &&
				   request.MessageId.EqualsOrdinalIgnoreCase(r.ChatMessage.MessageId) &&
				   entity.Sender != null && entity.Sender.Matches(r.ChatMessage.Sender) &&
				   entity.Chat != null && entity.Chat.Matches(r.ChatMessage.Chat) &&
				   entity.Content == r.ChatMessage.Content &&
				   entity.CreatedAtUtc == r.ChatMessage.CreatedAtUtc &&
				   entity.UpdatedAtUtc == r.ChatMessage.UpdatedAtUtc;
		}
	}

	extension(GetAllChatMessagesQueryRequest query)
	{
		public bool Matches(GetAllChatMessagesApiRequest request)
		{
			return query.MatchesFilter(request) &&
				   query.MatchesSortable<GetAllChatMessagesQueryRequest, ChatMessagesSortTerm, GetAllChatMessagesApiRequest>(request) &&
				   query.MatchesPaginatable(request) &&
				   query.MatchesCurrentUserable(request);
		}

		public bool MatchesFilter(GetAllChatMessagesApiRequest request)
		{
			return query.ParticipantTwoId == request.ParticipantTwoId;
		}
	}

	extension(GetChatMessageByIdQueryRequest query)
	{
		public bool Matches(GetChatMessageByIdApiRequest request)
		{
			return query.ParticipantTwoId == request.ParticipantTwoId &&
				   query.MessageId == request.MessageId &&
				   query.MatchesCurrentUserable(request);
		}
	}

	extension(AddChatMessageCommandRequest command)
	{
		public bool Matches(AddChatMessageApiRequest request)
		{
			return command.ParticipantOneId == request.ParticipantOneId &&
				   command.ParticipantTwoId == request.ParticipantTwoId &&
				   command.Content == request.Body.Content;
		}
	}

	extension(UpdateChatMessageCommandRequest command)
	{
		public bool Matches(UpdateChatMessageApiRequest request)
		{
			return command.ParticipantOneId == request.ParticipantOneId &&
				   command.ParticipantTwoId == request.ParticipantTwoId &&
				   command.MessageId == request.MessageId &&
				   command.Content == request.Body.Content;
		}
	}

	extension(DeleteChatMessageCommandRequest command)
	{
		public bool Matches(DeleteChatMessageApiRequest request)
		{
			return command.ParticipantOneId == request.ParticipantOneId &&
				   command.ParticipantTwoId == request.ParticipantTwoId &&
				   command.MessageId == request.MessageId;
		}
	}

	extension(AddChatMessageApiResponse response)
	{
		public bool Matches(
		AddChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			return response.Response.Matches(chatMessage.Id);
		}
	}

	extension(UpdateChatMessageApiResponse response)
	{
		public bool Matches(
		UpdateChatMessageApiRequest request,
		ChatMessage chatMessage)
		{
			return response.Response.Matches(chatMessage.Id);
		}
	}

	extension(GetChatMessageByIdApiResponse response)
	{
		public bool Matches(GetChatMessageByIdApiRequest request, ChatMessage chatMessage)
		{
			return response.Response.MatchesFull(request, chatMessage);
		}

		public bool MatchesInverted(GetChatMessageByIdApiRequest request, ChatMessage chatMessage)
		{
			return response.Response.MatchesFullInverted(request, chatMessage);
		}
	}

	extension(GetAllChatMessagesApiResponse response)
	{
		public bool Matches(
		GetAllChatMessagesApiRequest request,
		Chat chat,
		ICollection<ChatMessage> chatMessages)
		{
			return response.Response.MatchesWithoutSender(
					   request,
					   (response, chatMessage) => response.MatchesWithoutChat(request, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(request),
					   chat,
					   chatMessages);
		}

		public bool Matches(
			GetAllChatMessagesApiRequest request,
			Chat chat,
			ICollection<ChatMessage> chatMessages,
			ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.Response.MatchesWithoutSender(
					   request,
					   (response, chatMessage) => response.MatchesWithoutChat(request, chatMessage),
					   chatMessage => chatMessage.MatchesFilter(request),
					   chat,
					   chatMessages,
					   termTransformer);
		}

		public bool MatchesInverted(GetAllChatMessagesApiRequest request, Chat chat, ICollection<ChatMessage> chatMessages)
		{
			return response.Response.MatchesWithoutSenderInverted(
				request,
				(response, message) => response.MatchesWithoutChatInverted(request, message),
				message => message.MatchesFilter(request),
				chat,
				chatMessages);
		}

		public bool MatchesInverted(GetAllChatMessagesApiRequest request, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
		{
			return response.Response.MatchesWithoutSenderInverted(
				request,
				(response, message) => response.MatchesWithoutChatInverted(request, message),
				message => message.MatchesFilter(request),
				chat,
				chatMessages,
				termTransformer);
		}
	}

	extension(ChatMessage chatMessage)
	{
		public bool Matches(AddChatMessageApiRequest request)
		{
			return chatMessage.Id.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId) &&
				   chatMessage.Content == request.Body.Content;
		}

		public bool Matches(UpdateChatMessageApiRequest request)
		{
			return chatMessage.Id.Matches(request.ParticipantOneId, request.ParticipantTwoId, request.MessageId) &&
				   chatMessage.Content == request.Body.Content;
		}

		public bool MatchesInverted(AddChatMessageApiRequest request)
		{
			return chatMessage.Id.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId) &&
				   chatMessage.Content == request.Body.Content;
		}

		public bool MatchesInverted(UpdateChatMessageApiRequest request)
		{
			return chatMessage.Id.Matches(request.ParticipantTwoId, request.ParticipantOneId, request.MessageId) &&
				   chatMessage.Content == request.Body.Content;
		}

		public bool MatchesFilter(GetAllChatMessagesApiRequest request)
		{
			return (chatMessage.Id.Id.ParticipantOneId.Matches(request.CurrentUserId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(request.ParticipantTwoId)) ||
				   (chatMessage.Id.Id.ParticipantOneId.Matches(request.ParticipantTwoId) &&
				   chatMessage.Id.Id.ParticipantTwoId.Matches(request.CurrentUserId));
		}
	}

	extension(ChatMessageIdApiResponse response)
	{
		public bool Matches(ChatMessageId id)
		{
			return id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId);
		}
	}

	extension(ChatMessageApiResponse? response)
	{
		public bool MatchesFull<TRequest>(TRequest request, ChatMessage? chatMessage)
		where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFull(request, chatMessage.Chat);
		}

		public bool MatchesWithoutSender<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chatMessage.Chat);
		}

		public bool MatchesWithoutChat<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantOneId, response.ParticipantTwoId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}

		public bool MatchesFullInverted<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat.MatchesFullInverted(request, chatMessage.Chat);
		}

		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chatMessage.Chat);
		}

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, ChatMessage? chatMessage)
			where TRequest : ICurrentUserableApiRequest
		{
			return response != null &&
				   chatMessage != null &&
				   chatMessage.Id.Matches(response.ParticipantTwoId, response.ParticipantOneId, response.MessageId) &&
				   chatMessage.SenderId.Matches(response.SenderId) &&
				   chatMessage.Content == response.Content &&
				   chatMessage.CreatedAtUtc == response.CreatedAtUtc &&
				   chatMessage.UpdatedAtUtc == response.UpdatedAtUtc &&
				   response.Sender.MatchesFull(chatMessage.Sender) &&
				   response.Chat == null;
		}
	}

	extension(ChatMessageCollectionApiResponse response)
	{
		public bool MatchesWithoutSender<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages)
		where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutSender<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFull(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChat<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantOneId), new(response.ParticipantTwoId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChat<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}
		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutSenderInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, Chat chat, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender == null &&
				   response.Chat.MatchesFullInverted(request, chat) &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesCollection(
					   request,
					   chatMessages,
					   response => new(new(new(response.ParticipantTwoId), new(response.ParticipantOneId)), response.MessageId),
					   chatMessage => chatMessage.Id,
					   matches,
					   matchesFilter
				   );
		}

		public bool MatchesWithoutChatInverted<TRequest>(TRequest request, Func<ChatMessageApiResponse, ChatMessage, bool> matches, Func<ChatMessage, bool> matchesFilter, User user, ICollection<ChatMessage> chatMessages, ISortEnumTermTransformer<ChatMessage> termTransformer)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			return response.MatchesCollectionResponse(request, chatMessages.Count(matchesFilter)) &&
				   response.Sender.MatchesFull(user) &&
				   response.Chat == null &&
				   response.ChatMessages.MatchesSortedCollection(
					   request,
					   chatMessages,
					   matches,
					   termTransformer,
					   matchesFilter
				   );
		}
	}
}
