using InstaConnect.Common.Domain.Models;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Repositories;

internal class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly IIdentityContext _identityContext;
    private readonly IRefreshTokenIncludePropertyFactory _refreshTokenIncludePropertyFactory;

    public RefreshTokenRepository(
        IIdentityContext identityContext,
        IRefreshTokenIncludePropertyFactory refreshTokenIncludePropertyFactory)
    {
        _identityContext = identityContext;
        _refreshTokenIncludePropertyFactory = refreshTokenIncludePropertyFactory;
    }

    public async Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        CommonIncludeQuery<RefreshTokenIncludeProperty>? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _refreshTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .RefreshTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(id.GetFilter())
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(RefreshToken entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .RefreshTokens
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken)
    {
        await _identityContext.RefreshTokens
            .DeleteAsync(
            _identityContext.ClientSessionHandle,
            entity.Id.GetFilter(),
            cancellationToken);
    }
}
