﻿using InstaConnect.Identity.Business.Models;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Identity.Business.Queries.User.GetCurrentUser;

public class GetCurrentUserQuery : IQuery<UserViewModel>, ICachable
{
    private const int EXPIRATION_AMOUNT_MINUTES = 15;


    public string CurrentUserId { get; set; } = string.Empty;

    public string Key => nameof(GetCurrentUserQuery) + CurrentUserId;

    public DateTimeOffset Expiration => DateTimeOffset.UtcNow.AddMinutes(EXPIRATION_AMOUNT_MINUTES);
}