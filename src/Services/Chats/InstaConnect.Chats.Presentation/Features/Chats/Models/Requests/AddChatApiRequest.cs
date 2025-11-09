using System.Security.Claims;

namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record AddChatApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId
);
