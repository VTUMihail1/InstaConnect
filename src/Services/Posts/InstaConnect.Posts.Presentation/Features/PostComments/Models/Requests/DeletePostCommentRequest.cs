using InstaConnect.Shared.Presentation.Binders.FromClaim;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record DeletePostCommentRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
