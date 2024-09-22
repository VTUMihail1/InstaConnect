using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenFactory : IEmailConfirmationTokenFactory
{
    private readonly EmailConfirmationOptions _emailConfirmationOptions;

    public EmailConfirmationTokenFactory(IOptions<EmailConfirmationOptions> options)
    {
        _emailConfirmationOptions = options.Value;
    }

    public EmailConfirmationToken GetEmailConfirmationToken(string userId)
    {
        return new EmailConfirmationToken(
            Guid.NewGuid().ToString(),
            DateTime.Now.AddSeconds(_emailConfirmationOptions.LifetimeSeconds),
            userId);
    }
}
