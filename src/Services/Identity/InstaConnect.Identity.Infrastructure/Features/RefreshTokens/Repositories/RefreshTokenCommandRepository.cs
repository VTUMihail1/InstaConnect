using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Repositories;

internal class RefreshTokenCommandRepository : IRefreshTokenCommandRepository
{
    private readonly IIdentityContext _context;
    private readonly IRefreshTokenIncludePropertyFactory _refreshTokenIncludePropertyFactory;

    public RefreshTokenCommandRepository(
        IIdentityContext context,
        IRefreshTokenIncludePropertyFactory refreshTokenIncludePropertyFactory)
    {
        _context = context;
        _refreshTokenIncludePropertyFactory = refreshTokenIncludePropertyFactory;
    }

    public async Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        RefreshTokenInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .RefreshTokens
            .Aggregate()
            .Includes(_refreshTokenIncludePropertyFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<RefreshToken?> GetByIdAsync(
        RefreshTokenId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task AddAsync(RefreshToken entity, CancellationToken cancellationToken)
    {
        await _context
            .RefreshTokens
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task DeleteAsync(RefreshToken entity, CancellationToken cancellationToken)
    {
        await _context.RefreshTokens
            .DeleteAsync(
            _context.ClientSessionHandle,
            entity,
            cancellationToken);
    }
}
