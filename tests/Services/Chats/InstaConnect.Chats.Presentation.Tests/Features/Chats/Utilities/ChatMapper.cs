using InstaConnect.Chats.Presentation.Features.Users.Abstractions;
using InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;
using InstaConnect.Chats.Presentation.Tests.Features.Users.Utilities;
using InstaConnect.Common.Presentation.Features.Messaging.Abstractions;

namespace InstaConnect.Chats.Presentation.Tests.Features.Chats.Utilities;

public static class ChatMapper
{
	extension(Chat chat)
	{
		internal ChatIdCommandResponse ToIdResponse(
)
		{
			return new(chat.Id.ParticipantOneId.Id, chat.Id.ParticipantTwoId.Id);
		}

		internal ChatQueryResponse ToFullResponse()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatQueryResponse ToResponseWithoutParticipantOne()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   null,
					   chat.ParticipantTwo?.ToFullResponse(),
					   chat.CreatedAtUtc);
		}

		internal ChatQueryResponse ToResponseWithoutParticipantTwo()
		{
			return new(chat.Id.ParticipantOneId.Id,
					   chat.Id.ParticipantTwoId.Id,
					   chat.ParticipantOne?.ToFullResponse(),
					   null,
					   chat.CreatedAtUtc);
		}

		public AddChatCommandResponse ToResponse(
			AddChatApiRequest request)
		{
			return new(chat.ToIdResponse());
		}

		public GetChatByIdQueryResponse ToResponse(
			GetChatByIdApiRequest request)
		{
			return new(chat.ToFullResponse());
		}
	}

	extension(ICollection<Chat> chats)
	{
		internal ChatCollectionQueryResponse ToResponseWithoutParticipantTwo<TRequest>(
			User participantOne,
			Func<Chat, TRequest, bool> filter,
			Func<Chat, TRequest, ChatQueryResponse> transform,
			TRequest request)
			where TRequest : ICurrentUserableApiRequest, IPaginatableApiRequest
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

		public GetAllChatsQueryResponse ToResponse(
			User participantOne,
			GetAllChatsApiRequest request)
		{
			return new(chats.ToResponseWithoutParticipantTwo(
												   participantOne,
												   (chat, request) => chat.MatchesFilter(request),
												   (chat, request) => chat.ToResponseWithoutParticipantOne(),
												   request));
		}
	}
}
