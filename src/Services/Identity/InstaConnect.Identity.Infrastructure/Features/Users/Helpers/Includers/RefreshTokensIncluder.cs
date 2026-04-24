using InstaConnect.Identity.Domain.Features.Common.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class RefreshTokensIncluder : IUserIncluder
{
    private readonly IIdentityContext _context;

    public RefreshTokensIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.User;

    public IdentityIncludeType IncludeType => IdentityIncludeType.RefreshToken;

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
