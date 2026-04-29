using InstaConnect.Chats.Application.Features.Users.Abstractions;

namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

public record GetChatMessageByIdQueryRequest(
	string ParticipantTwoId,
	string MessageId,
	string CurrentUserId) : IQueryRequest<GetChatMessageByIdQueryResponse>, ICurrentUserableQueryRequest;
