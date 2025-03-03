﻿using System.Security.Claims;

using InstaConnect.Posts.Presentation.Features.PostLikes.Models.Bodies;
using InstaConnect.Shared.Presentation.Binders.FromClaim;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record AddPostLikeRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddPostLikeBody Body
);
