using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;

using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Repositories;

internal class EmailConfirmationTokenWriteRepository : IEmailConfirmationTokenWriteRepository
{
    private readonly IdentityContext _identityContext;

    public EmailConfirmationTokenWriteRepository(IdentityContext identityContext)
    {
        _identityContext = identityContext;
    }

    public async Task<EmailConfirmationToken?> GetByValueAsync(string value, CancellationToken cancellationToken)
    {
        var token = await _identityContext.EmailConfirmationTokens
            .FirstOrDefaultAsync(e => e.Value == value, cancellationToken);

        return token;
    }

    public void Add(EmailConfirmationToken emailConfirmationToken)
    {
        _identityContext
            .EmailConfirmationTokens
            .Add(emailConfirmationToken);
    }

    public void Delete(EmailConfirmationToken emailConfirmationToken)
    {
        _identityContext
            .EmailConfirmationTokens
            .Remove(emailConfirmationToken);
    }
}
