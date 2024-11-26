using InstaConnect.Identity.Application.Features.Users.Abstractions;
using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.Users.Helpers;

internal class ForgotPasswordTokenGenerator : IForgotPasswordTokenGenerator
{
    private readonly ForgotPasswordOptions _forgotPasswordOptions;

    public ForgotPasswordTokenGenerator(IOptions<ForgotPasswordOptions> options)
    {
        _forgotPasswordOptions = options.Value;
    }

    public GenerateForgotPasswordTokenResponse GenerateForgotPasswordToken(string userId, string email)
    {
        var value = Guid.NewGuid().ToString();

        return new(
            userId,
            email,
            DateTime.Now.AddSeconds(_forgotPasswordOptions.LifetimeSeconds),
            value,
            string.Format(_forgotPasswordOptions.UrlTemplate, userId, value));
    }
}
