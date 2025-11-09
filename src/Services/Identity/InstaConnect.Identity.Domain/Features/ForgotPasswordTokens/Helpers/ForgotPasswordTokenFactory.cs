using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Helpers;

internal class ForgotPasswordTokenFactory : IForgotPasswordTokenFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ForgotPasswordTokenOptions _forgotPasswordTokenOptions;

    public ForgotPasswordTokenFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider,
        IOptions<ForgotPasswordTokenOptions> options)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
        _forgotPasswordTokenOptions = options.Value;
    }

    public ForgotPasswordToken Create(string id)
    {
        var value = _guidProvider.NewGuid().ToString();
        var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_forgotPasswordTokenOptions.LifetimeSeconds);
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var forgotPasswordToken = new ForgotPasswordToken(
            id,
            value,
            expiresAt,
            utcNow,
            utcNow);

        return forgotPasswordToken;
    }
}
