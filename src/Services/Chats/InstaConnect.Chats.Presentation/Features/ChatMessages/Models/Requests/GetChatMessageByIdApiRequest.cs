using System.Security.Claims;

namespace InstaConnect.Chats.Presentation.Features.ChatMessages.Models.Requests;

public record GetChatMessageByIdApiRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string ParticipantOneId,
    [FromRoute] string ParticipantTwoId,
    [FromRoute] string MessageId,
    [FromClaim(ClaimTypes.NameIdentifier)] string SenderId
);
