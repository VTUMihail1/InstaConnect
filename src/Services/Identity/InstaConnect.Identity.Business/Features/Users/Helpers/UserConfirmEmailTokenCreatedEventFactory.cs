using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Shared.Business.Contracts.Emails;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Business.Features.Users.Helpers;

internal class UserConfirmEmailTokenCreatedEventFactory : IUserConfirmEmailTokenCreatedEventFactory
{
    private readonly EmailConfirmationOptions _emailConfirmationOptions;

    public UserConfirmEmailTokenCreatedEventFactory(IOptions<EmailConfirmationOptions> options)
    {
        _emailConfirmationOptions = options.Value;
    }

    public UserConfirmEmailTokenCreatedEvent GetUserConfirmEmailTokenCreatedEvent(string userId, string email, string token)
    {
        var c = string.Format(_emailConfirmationOptions.UrlTemplate, userId, token);

        return new(email, string.Format(_emailConfirmationOptions.UrlTemplate, userId, token));
    }
}
