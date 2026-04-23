using InstaConnect.Identity.Domain.Features.Common.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.Common.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class UserClaimsIncluder : IUserIncluder
{
    private readonly IIdentityContext _context;

    public UserClaimsIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.User;

    public IdentityIncludeType IncludeType => IdentityIncludeType.UserClaim;

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
