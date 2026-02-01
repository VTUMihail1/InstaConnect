using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includes;

public class UserClaimsIncludeProperty : IUserIncludeProperty
{
    private readonly IIdentityContext _context;

    public UserClaimsIncludeProperty(IIdentityContext context)
    {
        _context = context;
    }

    public UserIncludeProperty IncludeProperty => UserIncludeProperty.Claims;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.UserClaims,
                p => p.Id,
                l => l.Id.Id,
                p => p.UserClaims
            );
    }
}
