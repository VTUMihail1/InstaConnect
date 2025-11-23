using System.Security.Claims;

using InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Bodies;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record AddChatMessageApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromClaim(ClaimTypes.NameIdentifier)] string SenderId,
    [FromBody] AddChatMessageApiBody Body
);
