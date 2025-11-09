namespace InstaConnect.Chats.Application.Features.Chats.Queries.GetById;

public record GetChatByIdQueryRequest(string ParticipantOneId, string ParticipantTwoId) : IQueryRequest<GetChatByIdQueryResponse>;
