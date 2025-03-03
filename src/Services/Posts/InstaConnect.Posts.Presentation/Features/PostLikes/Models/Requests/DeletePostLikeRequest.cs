﻿using System.Security.Claims;

using InstaConnect.Shared.Presentation.Binders.FromClaim;

namespace InstaConnect.Posts.Presentation.Features.PostLikes.Models.Requests;

public record DeletePostLikeRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
