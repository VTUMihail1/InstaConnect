﻿using System.Security.Claims;
using InstaConnect.Posts.Presentation.Features.Posts.Models.Binding;
using InstaConnect.Shared.Presentation.Binders.FromClaim;
using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Posts.Presentation.Features.Posts.Models.Requests;

public record UpdatePostRequest(
    [FromRoute] string Id,
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] UpdatePostBody Body
);
