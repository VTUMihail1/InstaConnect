using System.Security.Claims;

namespace InstaConnect.ChatMessages.Presentation.Features.ChatMessages.Models.Requests;

public record DeleteChatMessageApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromRoute] string MessageId
);
