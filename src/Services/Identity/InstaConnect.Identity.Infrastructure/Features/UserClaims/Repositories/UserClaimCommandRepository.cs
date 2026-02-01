namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Repositories;

internal class UserClaimCommandRepository : IUserClaimCommandRepository
{
    private readonly IIdentityContext _context;

    public UserClaimCommandRepository(IIdentityContext _context)
    {
        this._context = _context;
    }

    public async Task AddAsync(UserClaim entity, CancellationToken cancellationToken)
    {
        await _context
            .UserClaims
            .AddAsync(_context.ClientSessionHandle, entity, cancellationToken);
    }
}
