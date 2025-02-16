﻿using System.Security.Claims;

using InstaConnect.Messages.Presentation.Features.Messages.Models.Bodies;
using InstaConnect.Shared.Presentation.Binders.FromClaim;

using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Messages.Presentation.Features.Messages.Models.Requests;

public record AddMessageRequest(
    [FromClaim(ClaimTypes.NameIdentifier)] string CurrentUserId,
    [FromBody] AddMessageBody Body);
