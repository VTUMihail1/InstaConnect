using System.Security.Claims;

using InstaConnect.Messages.Presentation.Features.ChatMessages.Models.Bodies;

namespace InstaConnect.ChatMessages.Presentation.Features.ChatMessages.Models.Requests;

public record AddChatMessageApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromBody] AddChatMessageApiBody Body
);
