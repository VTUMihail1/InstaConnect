using System.Security.Claims;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Bodies;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;

public record AddPostCommentLikeRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddPostCommentLikeBody Body
);
