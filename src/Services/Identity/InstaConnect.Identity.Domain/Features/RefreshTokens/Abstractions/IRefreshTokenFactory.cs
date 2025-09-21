using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;

using System;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenFactory
{
    public RefreshToken Create(string id);
}
