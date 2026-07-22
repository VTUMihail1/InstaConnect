using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		internal ChatIdCommandResponse ToIdCommandResponse(
)
		{
			return new(chat.Id.ParticipantOneId.Id, chat.Id.ParticipantTwoId.Id);
		}

		internal ChatQueryResponse ToFullQueryResponse()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   chat.ParticipantOne?.ToFullQueryResponse(),
					   chat.ParticipantTwo?.ToFullQueryResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatQueryResponse ToQueryResponseWithoutParticipantOne()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   null,
					   chat.ParticipantTwo?.ToFullQueryResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatQueryResponse ToQueryResponseWithoutParticipantTwo()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   chat.ParticipantOne?.ToFullQueryResponse(),
					   null,
					   chat.CreatedAtUtc);
		}

		public AddChatCommandResponse ToResponse(
			AddChatApiRequest request)
		{
			return new(chat.ToIdCommandResponse());
		}

		public GetChatByIdQueryResponse ToResponse(
			GetChatByIdApiRequest request)
		{
			return new(chat.ToFullQueryResponse());
		}
	}

	extension(ICollection<Chat> chats)
	{
		internal ChatCollectionQueryResponse ToQueryResponseWithoutParticipantTwo<TRequest>(
			User participantOne,
			Func<Chat, TRequest, bool> filter,
			Func<Chat, TRequest, ChatQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
		{
			var paginator = new Paginator();
			var totalCount = chats.Count(chat => filter(chat, request));

			return new(participantOne.ToFullQueryResponse(),
					   null,
					   chats.Filter(request, chat => filter(chat, request), chat => transform(chat, request)),
					   request.Page,
					   request.PageSize,
					   totalCount,
					   paginator.HasNextPage(request.Page, request.PageSize, totalCount),
					   paginator.HasPreviousPage(request.Page));
		}

		public GetAllChatsQueryResponse ToResponse(
			User participantOne,
			GetAllChatsApiRequest request)
		{
			return new(chats.ToQueryResponseWithoutParticipantTwo(
												   participantOne,
												   (chat, request) => chat.MatchesFilter(request),
												   (chat, request) => chat.ToQueryResponseWithoutParticipantOne(),
												   request));
		}
	}
}
