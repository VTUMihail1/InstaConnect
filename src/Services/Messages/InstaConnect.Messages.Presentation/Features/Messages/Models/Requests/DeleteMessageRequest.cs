using System.Security.Claims;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public record DeleteMessageRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId);
