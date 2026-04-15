using InstaConnect.Identity.Infrastructure.Features.RefreshTokens.Extensions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Extensions;
using InstaConnect.Identity.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimCommandRepository : IUserClaimCommandRepository
{
    private readonly IIdentityContext _context;
    private readonly IUserClaimIncluderFactory _includePropertyFactory;

    public UserClaimCommandRepository(
        IIdentityContext context,
        IUserClaimIncluderFactory includePropertyFactory)
    {
        _context = context;
        _includePropertyFactory = includePropertyFactory;
    }

    public async Task<UserClaim?> GetByIdAsync(
        UserClaimId id,
        UserClaimInclude? include,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Includes(_includePropertyFactory, include)
            .Match(id)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<UserClaim?> GetByIdAsync(
        UserClaimId id,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, null, cancellationToken);
    }

    public async Task<bool> ExistsByIdAsync(
        UserClaimId id,
        CancellationToken cancellationToken)
    {
        return await _context
            .UserClaims
            .AggregateWithCaseInsensitiveCollation()
            .Match(id)
            .AnyAsync(cancellationToken);
    }

    public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
    {
        await _context
            .UserClaims
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<UserClaim> entities, CancellationToken cancellationToken)
    {
        await _context
            .UserClaims
            .AddRangeAsync(_context.ClientSessionHandle, entities, cancellationToken);
    }

    public async Task DeleteAsync(UserClaim entity, CancellationToken cancellationToken)
    {
        await _context
            .UserClaims
            .DeleteAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
