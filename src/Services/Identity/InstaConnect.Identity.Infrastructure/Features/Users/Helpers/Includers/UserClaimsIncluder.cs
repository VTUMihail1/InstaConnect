using InstaConnect.Identity.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class UserClaimsIncluder : IUserIncluder
{
    private readonly IIdentityContext _context;

    public UserClaimsIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.Users;

    public IdentityIncludeType IncludeType => IdentityIncludeType.UserClaims;

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
