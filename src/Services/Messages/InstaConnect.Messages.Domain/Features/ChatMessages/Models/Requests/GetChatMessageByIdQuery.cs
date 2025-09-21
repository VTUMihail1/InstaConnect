namespace InstaConnect.ChatMessages.Application.Features.ChatMessages.Queries.GetById;

public record GetChatMessageByIdQuery(string ParticipantOneId, string ParticipantTwoId, string MessageId);
