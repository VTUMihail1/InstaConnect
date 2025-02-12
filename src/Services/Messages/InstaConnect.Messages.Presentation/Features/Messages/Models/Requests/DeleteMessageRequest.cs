using System.Security.Claims;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public record DeleteMessageRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId);
