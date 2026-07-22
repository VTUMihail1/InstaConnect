using InstaConnect.Chats.Domain.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Domain.Tests.Features.Users.Utilities;

namespace InstaConnect.Chats.Domain.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(Chat chat)
	{
		public ChatResponse ToResponse(
			GetAllChatMessagesQuery query)
		{
			return chat.ToFullResponse(query);
		}
	}

	extension(ChatMessage chatMessage)
	{
		internal ChatMessageResponse ToFullResponse<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(request),
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageResponse ToResponseWithoutSender<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(request),
					   null,
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageResponse ToResponseWithoutChat<T>(
			T request)
			where T : ICurrentUserableQuery
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.SenderId,
					   null,
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		public ChatMessage To(AddChatMessageCommand command)
		{
			return new(
				new(command.Id, chatMessage.Id.MessageId),
				command.Id.ParticipantOneId,
				command.Content,
				chatMessage.CreatedAtUtc,
				chatMessage.UpdatedAtUtc);
		}

		public ChatMessageId ToResponse(
			AddChatMessageCommand command)
		{
			return chatMessage.ToId();
		}

		public ChatMessageId ToResponse(
			UpdateChatMessageCommand command)
		{
			return chatMessage.ToId();
		}

		public ChatMessageResponse ToResponse(
			GetChatMessageByIdQuery query)
		{
			return chatMessage.ToFullResponse(query);
		}
	}

	extension(ICollection<ChatMessage> chatMessages)
	{
		public ICollection<ChatMessageResponse> ToResponse(
			GetAllChatMessagesQuery query)
		{
			return chatMessages.Filter(query.Pagination, chatMessage => chatMessage.MatchesFilter(query), chatMessage => chatMessage.ToResponseWithoutChat(query));
		}

		public long ToTotalCountResponse(
			GetAllChatMessagesQuery query)
		{
			return chatMessages.Count(chatMessage => chatMessage.MatchesFilter(query));
		}
	}
}
