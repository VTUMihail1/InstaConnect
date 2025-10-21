using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Posts.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenIncludeProperty : IIncludeProperty<RefreshToken>
{
    public RefreshTokenIncludeProperty IncludeProperty { get; }
}
