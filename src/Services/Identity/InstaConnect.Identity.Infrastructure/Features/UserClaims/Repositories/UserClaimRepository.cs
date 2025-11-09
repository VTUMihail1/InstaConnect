using InstaConnect.Identity.Infrastructure.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimRepository : IUserClaimRepository
{
    private readonly IIdentityContext _identityContext;
    private readonly IUserClaimIncludePropertyFactory _userClaimIncludePropertyFactory;

    public UserClaimRepository(
        IIdentityContext identityContext,
        IUserClaimIncludePropertyFactory userClaimIncludePropertyFactory)
    {
        _identityContext = identityContext;
        _userClaimIncludePropertyFactory = userClaimIncludePropertyFactory;
    }

    public async Task<UserClaim?> GetByIdAsync(
        string id,
        string value,
        UserClaimIncludeQuery? include,
        CancellationToken cancellationToken)
    {
        var includeProperties = _userClaimIncludePropertyFactory.Create(include?.Properties);

        var entity = await _identityContext
            .UserClaims
            .Aggregate()
            .Includes(includeProperties)
            .Match(p => p.Id == id && p.Value == value)
            .FirstOrDefaultAsync(cancellationToken);

        return entity;
    }

    public async Task<UserClaim?> GetByIdAsync(
        string id,
        string value,
        CancellationToken cancellationToken)
    {
        return await GetByIdAsync(id, value, null, cancellationToken);
    }

    public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .UserClaims
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }
}
