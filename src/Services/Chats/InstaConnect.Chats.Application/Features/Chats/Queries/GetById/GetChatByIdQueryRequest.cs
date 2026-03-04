using InstaConnect.Chats.Application.Features.Users.Abstractions;

namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public record GetChatByIdQueryRequest(
    string ParticipantOneId,
    string ParticipantTwoId,
    string CurrentUserId)
    : IQueryRequest<GetChatByIdQueryResponse>, ICurrentUserableQueryRequest;
