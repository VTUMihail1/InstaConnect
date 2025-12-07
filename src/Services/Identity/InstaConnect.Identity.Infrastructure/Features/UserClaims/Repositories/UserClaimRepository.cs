namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimRepository : IUserClaimRepository
{
    private readonly IIdentityContext _identityContext;

    public UserClaimRepository(IIdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
    {
        await _identityContext
            .UserClaims
            .AddAsync(_identityContext.ClientSessionHandle, entity, cancellationToken);
    }
}
