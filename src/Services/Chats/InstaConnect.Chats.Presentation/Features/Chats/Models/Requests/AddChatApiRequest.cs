namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record AddChatApiRequest(
    [UserIdFromClaim] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId
);
