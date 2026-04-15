using InstaConnect.Identity.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers.Includers;

internal class EmailConfirmationTokensIncluder : IUserIncluder
{
    private readonly IIdentityContext _context;

    public EmailConfirmationTokensIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.User;

    public IdentityIncludeType IncludeType => IdentityIncludeType.EmailConfirmationToken;

    public IAggregateFluent<User> Include(IAggregateFluent<User> aggregate)
    {
        return aggregate
            .IncludeMany(
                _context.EmailConfirmationTokens,
                p => p.Id,
                l => l.Id.Id,
                p => p.EmailConfirmationTokens
            );
    }
}
