using InstaConnect.Chats.Application.Features.Users.Abstractions;
using InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Application.Tests.Features.Users.Utilities;
using InstaConnect.Common.Application.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Application.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		internal ChatId ToIdResponse(
)
		{
			return chat.Id;
		}

		internal ChatResponse ToFullResponse()
		{
			return new(chat.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatResponse ToResponseWithoutParticipantOne()
		{
			return new(chat.Id,
					   null,
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatResponse ToResponseWithoutParticipantTwo()
		{
			return new(chat.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   null,
					   chat.CreatedAtUtc);
		}

		public ChatId ToResponse(
			AddChatCommandRequest request)
		{
			return chat.ToIdResponse();
		}

		public ChatResponse ToResponse(
			GetChatByIdQueryRequest request)
		{
			return chat.ToFullResponse();
		}
	}

	extension(ICollection<Chat> chats)
	{
		internal ChatCollectionResponse ToResponseWithoutParticipantOne<TRequest>(
			User participantTwo,
			Func<Chat, TRequest, bool> filter,
			Func<Chat, TRequest, ChatResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chats.Count(chat => filter(chat, request));

			return new(null,
					   participantTwo.ToFullResponse(),
					   chats.Filter(chat => filter(chat, request), request, chat => transform(chat, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		internal ChatCollectionResponse ToResponseWithoutParticipantTwo<TRequest>(
			User participantOne,
			Func<Chat, TRequest, bool> filter,
			Func<Chat, TRequest, ChatResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableQueryRequest, IPaginatableQueryRequest
		{
			var paginator = new Paginator();
			var totalCount = chats.Count(chat => filter(chat, request));

			return new(participantOne.ToFullResponse(),
					   null,
					   chats.Filter(chat => filter(chat, request), request, chat => transform(chat, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public ChatCollectionResponse ToResponse(
			User participantOne,
			GetAllChatsQueryRequest request)
		{
			return chats.ToResponseWithoutParticipantTwo(
				participantOne,
				(chat, request) => chat.MatchesFilter(request),
				(chat, request) => chat.ToResponseWithoutParticipantOne(),
				request);
		}
	}
}
