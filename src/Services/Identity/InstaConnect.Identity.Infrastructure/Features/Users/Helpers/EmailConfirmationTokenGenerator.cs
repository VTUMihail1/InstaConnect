using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Infrastructure.Features.EmailConfirmationTokens.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers;

internal class EmailConfirmationTokenGenerator : IEmailConfirmationTokenGenerator
{
    private readonly EmailConfirmationOptions _emailConfirmationOptions;

    public EmailConfirmationTokenGenerator(IOptions<EmailConfirmationOptions> options)
    {
        _emailConfirmationOptions = options.Value;
    }

    public GenerateEmailConfirmationTokenResponse GenerateEmailConfirmationToken(string userId, string email)
    {
        var value = Guid.NewGuid().ToString();

        return new(
            userId,
            email,
            DateTime.Now.AddSeconds(_emailConfirmationOptions.LifetimeSeconds),
            value,
            string.Format(_emailConfirmationOptions.UrlTemplate, userId, value));
    }
}
