using System.Security.Claims;

using InstaConnect.Messages.Presentation.Features.ChatMessages.Models.Bodies;

namespace InstaConnect.ChatMessages.Presentation.Features.ChatMessages.Models.Requests;

public record UpdateChatMessageApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromRoute] string MessageId,
    [FromBody] UpdateChatMessageApiBody Body
);
