﻿namespace InstaConnect.Identity.Application.Features.Users.Models;

public record AccessTokenResult(string Value, DateTimeOffset ValidUntil);
