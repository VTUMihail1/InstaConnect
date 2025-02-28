using System.Security.Claims;

using InstaConnect.Messages.Presentation.Features.Messages.Models.Bodies;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public record UpdateMessageRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] UpdateMessageBody Body);
