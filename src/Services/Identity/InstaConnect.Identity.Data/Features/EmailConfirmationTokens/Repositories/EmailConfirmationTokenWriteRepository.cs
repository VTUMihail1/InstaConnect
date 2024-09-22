using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Repositories;

internal class EmailConfirmationTokenWriteRepository : BaseWriteRepository<EmailConfirmationToken>, IEmailConfirmationTokenWriteRepository
{
    private readonly IdentityContext _identityContext;

    public EmailConfirmationTokenWriteRepository(IdentityContext identityContext) : base(identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<EmailConfirmationToken?> GetByValueAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _identityContext.EmailConfirmationTokens
            .FirstOrDefaultAsync(e => e.Value == value, cancellationToken);

        return token;
    }
}
