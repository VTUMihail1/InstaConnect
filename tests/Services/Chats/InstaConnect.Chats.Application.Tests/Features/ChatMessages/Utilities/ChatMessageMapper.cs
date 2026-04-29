using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Users.Utilities;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(ChatMessage chatMessage)
	{
		internal ChatMessageId ToIdResponse(
)
		{
			return chatMessage.Id;
		}

		internal ChatMessageResponse ToFullResponse()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(),
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageResponse ToResponseWithoutSender()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.SenderId,
					   chatMessage.Chat?.ToFullResponse(),
					   null,
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageResponse ToResponseWithoutChat()
		{
			return new(chatMessage.Id,
					   chatMessage.Content,
					   chatMessage.SenderId,
					   null,
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		public ChatMessageId ToResponse(
			AddChatMessageCommandRequest request)
		{
			return chatMessage.ToIdResponse();
		}

		public ChatMessageId ToResponse(
			UpdateChatMessageCommandRequest request)
		{
			return chatMessage.ToIdResponse();
		}

		public ChatMessageResponse ToResponse(
			GetChatMessageByIdQueryRequest request)
		{
			return chatMessage.ToFullResponse();
		}
	}

	extension(ICollection<ChatMessage> chatMessages)
	{
		internal ChatMessageCollectionResponse ToResponseWithoutSender<TRequest>(
		Chat chat,
		Func<ChatMessage, TRequest, bool> filter,
		Func<ChatMessage, TRequest, ChatMessageResponse> transform,
		TRequest request)
		where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chatMessages.Count(chatMessage => filter(chatMessage, request));

			return new(chat.ToFullResponse(),
					   null,
					   chatMessages.Filter(chatMessage => filter(chatMessage, request), request, chatMessage => transform(chatMessage, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal ChatMessageCollectionResponse ToResponseWithoutChat<TRequest>(
			User user,
			Func<ChatMessage, TRequest, bool> filter,
			Func<ChatMessage, TRequest, ChatMessageResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chatMessages.Count(chatMessage => filter(chatMessage, request));

			return new(null,
					   user.ToFullResponse(),
					   chatMessages.Filter(chatMessage => filter(chatMessage, request), request, chatMessage => transform(chatMessage, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public ChatMessageCollectionResponse ToResponse(
			Chat chat,
			GetAllChatMessagesQueryRequest request)
		{
			return chatMessages.ToResponseWithoutSender(chat,
													  (chatMessage, request) => chatMessage.MatchesFilter(request),
													  (chatMessage, request) => chatMessage.ToResponseWithoutChat(),
													  request);
		}
	}
}
