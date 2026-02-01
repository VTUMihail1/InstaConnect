using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;

public class UserRefreshTokensIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _context;

    public UserRefreshTokensIncludeProperty(IIdentityContext context)
    {
        _context = context;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.RefreshTokens;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.RefreshTokens,
                p => p.Id,
                l => l.Id.Id,
                p => p.RefreshTokens
            );
    }
}
