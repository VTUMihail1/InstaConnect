using InstaConnect.Identity.Business.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.EmailConfirmationTokens.Models.Options;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Options;
using InstaConnect.Shared.Business.Contracts.Emails;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Business.Features.Users.Helpers;

internal class UserForgotPasswordTokenCreatedEventFactory : IUserForgotPasswordTokenCreatedEventFactory
{
    private readonly ForgotPasswordOptions _forgotPasswordOptions;

    public UserForgotPasswordTokenCreatedEventFactory(IOptions<ForgotPasswordOptions> options)
    {
        _forgotPasswordOptions = options.Value;
    }

    public UserForgotPasswordTokenCreatedEvent GetUserForgotPasswordTokenCreatedEvent(string userId, string email, string token)
    {
        return new(email, string.Format(_forgotPasswordOptions.UrlTemplate, userId, token));
    }
}
