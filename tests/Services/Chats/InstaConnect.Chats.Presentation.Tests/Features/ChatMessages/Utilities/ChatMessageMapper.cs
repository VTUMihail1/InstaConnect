using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.ChatMessages.Utilities;

public static class ChatMessageMapper
{
	extension(ChatMessage chatMessage)
	{
		internal ChatMessageIdCommandResponse ToIdResponse(
)
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id, chatMessage.Id.Id.ParticipantTwoId.Id, chatMessage.Id.MessageId);
		}

		internal ChatMessageQueryResponse ToFullResponse()
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id,
					   chatMessage.Id.Id.ParticipantTwoId.Id,
					   chatMessage.Id.MessageId,
					   chatMessage.SenderId.Id,
					   chatMessage.Content,
					   chatMessage.Chat?.ToFullResponse(),
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageQueryResponse ToResponseWithoutSender()
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id,
					   chatMessage.Id.Id.ParticipantTwoId.Id,
					   chatMessage.Id.MessageId,
					   chatMessage.SenderId.Id,
					   chatMessage.Content,
					   chatMessage.Chat?.ToFullResponse(),
					   null,
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		internal ChatMessageQueryResponse ToResponseWithoutChat()
		{
			return new(chatMessage.Id.Id.ParticipantOneId.Id,
					   chatMessage.Id.Id.ParticipantTwoId.Id,
					   chatMessage.Id.MessageId,
					   chatMessage.SenderId.Id,
					   chatMessage.Content,
					   null,
					   chatMessage.Sender?.ToFullResponse(),
					   chatMessage.CreatedAtUtc,
					   chatMessage.UpdatedAtUtc);
		}

		public AddChatMessageCommandResponse ToResponse(
			AddChatMessageApiRequest request)
		{
			return new(chatMessage.ToIdResponse());
		}

		public UpdateChatMessageCommandResponse ToResponse(
			UpdateChatMessageApiRequest request)
		{
			return new(chatMessage.ToIdResponse());
		}

		public GetChatMessageByIdQueryResponse ToResponse(
			GetChatMessageByIdApiRequest request)
		{
			return new(chatMessage.ToFullResponse());
		}
	}


	extension(ICollection<ChatMessage> chatMessages)
	{
		internal ChatMessageCollectionQueryResponse ToResponseWithoutSender<TRequest>(
		Chat chat,
		Func<ChatMessage, TRequest, bool> filter,
		Func<ChatMessage, TRequest, ChatMessageQueryResponse> transform,
		TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		internal ChatMessageCollectionQueryResponse ToResponseWithoutChat<TRequest>(
			User user,
			Func<ChatMessage, TRequest, bool> filter,
			Func<ChatMessage, TRequest, ChatMessageQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		public GetAllChatMessagesQueryResponse ToResponse(
			Chat chat,
			GetAllChatMessagesApiRequest request)
		{
			return new(chatMessages.ToResponseWithoutSender(chat,
					   (chatMessage, request) => chatMessage.MatchesFilter(request),
					   (chatMessage, request) => chatMessage.ToResponseWithoutChat(),
					   request));
		}
	}
}
