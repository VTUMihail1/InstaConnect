namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record DeleteChatApiRequest(
    [UserIdFromClaim] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId
);
