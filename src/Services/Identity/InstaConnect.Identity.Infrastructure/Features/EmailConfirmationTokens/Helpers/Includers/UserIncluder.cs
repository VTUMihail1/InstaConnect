using InstaConnect.Identity.Domain.Models.Requests;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Includers;

internal class UserIncluder : IEmailConfirmationTokenIncluder
{
    private readonly IIdentityContext _context;

    public UserIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.EmailConfirmationTokens;

    public IdentityIncludeType IncludeType => IdentityIncludeType.Users;

    public IAggregateFluent<EmailConfirmationToken> Include(IAggregateFluent<EmailConfirmationToken> aggregate)
    {
        return aggregate
            .IncludeOne(
                _context.Users,
                p => p.Id.Id,
                l => l.Id,
                p => p.User!
            );
    }
}
