namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenRepository
{
    Task<RefreshToken?> GetByIdAsync(
        string id,
        string value,
        RefreshTokenIncludeQuery include,
        CancellationToken cancellationToken);

    Task<RefreshToken?> GetByIdAsync(
        string id,
        string value,
        CancellationToken cancellationToken);

    Task AddAsync(RefreshToken entity, CancellationToken cancellationToken);

    Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken);
}
