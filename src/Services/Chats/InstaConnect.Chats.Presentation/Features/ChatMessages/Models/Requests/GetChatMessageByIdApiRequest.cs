namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdApiRequest(
    [UserIdFromClaim] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromRoute] string MessageId,
    [UserIdFromClaim] string CurrentUserId
);
