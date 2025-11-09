namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

public record RotateRefreshTokenCommandResponse(
    RefreshTokenCommandResponse RefreshToken,
    AccessTokenCommandResponse AccessToken);
