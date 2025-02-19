using System.Globalization;

using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Models;
using InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Features.ForgotPasswordTokens.Helpers;

internal class ForgotPasswordTokenGenerator : IForgotPasswordTokenGenerator
{
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ForgotPasswordOptions _forgotPasswordOptions;

    public ForgotPasswordTokenGenerator(
        IDateTimeProvider dateTimeProvider,
        IOptions<ForgotPasswordOptions> options)
    {
        _dateTimeProvider = dateTimeProvider;
        _forgotPasswordOptions = options.Value;
    }

    public GenerateForgotPasswordTokenResponse GenerateForgotPasswordToken(string userId, string email)
    {
        var value = Guid.NewGuid().ToString();

        return new(
            userId,
            email,
            _dateTimeProvider.GetUtcNow(_forgotPasswordOptions.LifetimeSeconds),
            value,
            string.Format(
                CultureInfo.InvariantCulture,
                _forgotPasswordOptions.UrlTemplate,
                userId,
                value));
    }
}
