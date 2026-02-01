namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;

public interface IRefreshTokenCommandRepository
{
    Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        RefreshTokenInclude? include,
        CancellationToken cancellationToken);

    Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        CancellationToken cancellationToken);

    Task AddAsync(RefreshToken entity, CancellationToken cancellationToken);

    Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken);
}
