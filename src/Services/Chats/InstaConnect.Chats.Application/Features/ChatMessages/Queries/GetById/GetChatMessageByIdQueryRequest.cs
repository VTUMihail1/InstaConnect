namespace InstaConnect.Chats.Application.Features.ChatMessages.Queries.GetById;

public record GetChatMessageByIdQueryRequest(
    string ParticipantOneId,
    string ParticipantTwoId,
    string MessageId,
    string UserId) : IQueryRequest<GetChatMessageByIdQueryResponse>;
