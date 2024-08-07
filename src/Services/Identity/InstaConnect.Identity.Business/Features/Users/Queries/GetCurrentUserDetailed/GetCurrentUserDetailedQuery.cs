﻿using InstaConnect.Identity.Business.Features.Users.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Features.Users.Queries.GetCurrentUserDetailed;

public record GetCurrentUserDetailedQuery(string CurrentUserId) : IQuery<UserDetailedQueryViewModel>, ICachable
{
    private const int CACHE_EXPIRATION_AMOUNT = 15;

    public string Key => $"{nameof(GetCurrentUserDetailedQuery)}-{CurrentUserId}";

    public DateTimeOffset Expiration => DateTimeOffset.UtcNow.AddMinutes(CACHE_EXPIRATION_AMOUNT);
}