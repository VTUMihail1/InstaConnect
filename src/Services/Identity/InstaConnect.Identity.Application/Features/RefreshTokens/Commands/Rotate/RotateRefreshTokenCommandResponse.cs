namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

public record RotateRefreshTokenCommandResponse(
    RefreshTokenIdCommandResponse Id,
    AccessTokenCommandResponse AccessToken,
    DateTimeOffset ExpiresAtUtc);
