using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Helpers;

internal class EmailConfirmationTokenFactory : IEmailConfirmationTokenFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly EmailConfirmationTokenOptions _emailConfirmationTokenOptions;

    public EmailConfirmationTokenFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider,
        IOptions<EmailConfirmationTokenOptions> options)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
        _emailConfirmationTokenOptions = options.Value;
    }

    public EmailConfirmationToken Create(string id)
    {
        var value = _guidProvider.NewGuid().ToString();
        var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_emailConfirmationTokenOptions.LifetimeSeconds);
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var emailConfirmationToken = new EmailConfirmationToken(
            id,
            value,
            expiresAt,
            utcNow,
            utcNow);

        return emailConfirmationToken;
    }
}
