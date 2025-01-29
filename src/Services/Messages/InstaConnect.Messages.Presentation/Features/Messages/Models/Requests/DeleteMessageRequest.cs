using InstaConnect.Shared.Presentation.Binders.FromClaim;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public class DeleteMessageRequest
{
    [FromRoute]
    public string Id { get; set; } = string.Empty;

    [FromClaim(ClaimTypes.NameIdentifier)]
    public string CurrentUserId { get; set; } = string.Empty;
}
