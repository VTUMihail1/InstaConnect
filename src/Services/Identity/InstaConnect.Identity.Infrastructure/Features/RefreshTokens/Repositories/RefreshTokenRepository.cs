using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.RefreshTokens.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Users.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.RefreshTokens.Infrastructure.Features.RefreshTokens.Repositories;

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
        string id,
        string value,
        RefreshTokenIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _refreshTokenIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .RefreshTokens
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id && p.Value == value)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<RefreshToken?> GetByIdAsync(
        string id,
        string value,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, value, null, cancellationToken);
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
            x => x.Id == entity.Id && x.Value == entity.Value,
            cancellationToken);
    }
}
