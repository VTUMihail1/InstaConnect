using InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetAll;

namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetById;

public record GetChatMessageByIdQueryRequest(string ParticipantOneId, string ParticipantTwoId, string MessageId) : IQueryRequest<GetChatMessageByIdQueryResponse>;
