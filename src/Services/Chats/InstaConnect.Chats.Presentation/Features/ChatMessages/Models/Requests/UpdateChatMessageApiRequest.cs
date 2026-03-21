using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Bodies;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record UpdateChatMessageApiRequest(
    [UserIdFromClaim] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromRoute] string MessageId,
    [UserIdFromClaim] string SenderId,
    [FromBody] UpdateChatMessageApiBody Body
);
