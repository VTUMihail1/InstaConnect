using System.Security.Claims;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;

public class DeleteFollowRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;

    [FromClaim(ClaimTypes.NameIdentifier)]
    public string CurrentUserId { get; set; } = string.Empty;
}
