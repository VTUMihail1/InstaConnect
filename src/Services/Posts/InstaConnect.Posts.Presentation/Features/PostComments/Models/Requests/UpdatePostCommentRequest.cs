using System.Security.Claims;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Bodies;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;

public record UpdatePostCommentRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] UpdatePostCommentBody Body
);
