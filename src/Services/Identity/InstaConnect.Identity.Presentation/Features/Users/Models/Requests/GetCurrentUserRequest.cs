﻿using System.Security.Claims;

using InstaConnect.Shared.Presentation.Binders.FromClaim;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetCurrentUserRequest([FromClaim(ClaimTypes.NameIdentifier)] string Id);
