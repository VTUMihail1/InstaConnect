using System.Security.Claims;

using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Bodies;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record UpdateChatMessageApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromRoute] string MessageId,
    [FromClaim(ClaimTypes.NameIdentifier)] string SenderId,
    [FromBody] UpdateChatMessageApiBody Body
);
