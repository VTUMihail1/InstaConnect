namespace InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

public record AddChatCommand(string ParticipantOneId, string ParticipantTwoId);
