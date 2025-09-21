using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Responses;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByIdAsync(string id, string value, CancellationToken cancellationToken);

    void Add(RefreshToken refreshToken);

    void Delete(RefreshToken refreshToken);
}
