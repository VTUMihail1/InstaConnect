﻿using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Identity.Data.Models.Entities;

namespace InstaConnect.Identity.Data.Factories;

internal class TokenFactory : ITokenFactory
{
    public Token GetTokenToken(string userId, string value, string type, int validUntil)
    {
        return new Token()
        {
            UserId = userId,
            Value = value,
            Type = type,
            ValidUntil = DateTime.Now.AddSeconds(validUntil)
        };
    }
}