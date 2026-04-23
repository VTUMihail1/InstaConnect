using InstaConnect.Identity.Domain.Features.Common.Models.Requests;
using InstaConnect.Identity.Infrastructure.Features.Common.Abstractions;

using MongoDB.Driver;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Helpers.Includers;

internal class UserIncluder : IEmailConfirmationTokenIncluder
{
    private readonly IIdentityContext _context;

    public UserIncluder(IIdentityContext context)
    {
        _context = context;
    }

    public IdentityDestinationType DestinationType => IdentityDestinationType.EmailConfirmationToken;

    public IdentityIncludeType IncludeType => IdentityIncludeType.User;

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
