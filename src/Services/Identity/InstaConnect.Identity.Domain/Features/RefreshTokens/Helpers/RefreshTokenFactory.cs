using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Helpers;

internal class RefreshTokenFactory : IRefreshTokenFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly RefreshTokenOptions _refreshTokenOptions;

    public RefreshTokenFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider,
        IOptions<RefreshTokenOptions> options)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
        _refreshTokenOptions = options.Value;
    }

    public RefreshToken Create(string id)
    {
        var value = _guidProvider.NewGuid().ToString();
        var expiresAt = _dateTimeProvider.GetOffsetUtcNow(_refreshTokenOptions.LifetimeSeconds);
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var refreshToken = new RefreshToken(
            id,
            value,
            expiresAt,
            utcNow,
            utcNow);

        return refreshToken;
    }
}
