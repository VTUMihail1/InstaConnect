namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        RefreshTokenIncludeQuery include,
        CancellationToken cancellationToken);

    Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        CancellationToken cancellationToken);

    Task AddAsync(RefreshToken entity, CancellationToken cancellationToken);

    Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken);
}
