﻿using System.Security.Claims;

using InstaConnect.Shared.Presentation.Binders.FromClaim;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record DeletePostRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId
);
