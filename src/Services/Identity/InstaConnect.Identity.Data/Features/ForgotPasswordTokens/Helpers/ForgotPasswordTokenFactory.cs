using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Models.Options;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Data.Features.ForgotPasswordTokens.Helpers;

internal class ForgotPasswordTokenFactory : IForgotPasswordTokenFactory
{
    private readonly ForgotPasswordOptions _forgotPasswordOptions;

    public ForgotPasswordTokenFactory(IOptions<ForgotPasswordOptions> options)
    {
        _forgotPasswordOptions = options.Value;
    }

    public ForgotPasswordToken GetForgotPasswordToken(string userId)
    {
        return new ForgotPasswordToken(
            Guid.NewGuid().ToString(),
            DateTime.Now.AddSeconds(_forgotPasswordOptions.LifetimeSeconds),
            userId);
    }
}
