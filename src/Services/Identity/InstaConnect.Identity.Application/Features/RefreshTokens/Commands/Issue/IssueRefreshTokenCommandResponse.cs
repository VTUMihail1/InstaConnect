namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;

public record IssueRefreshTokenCommandResponse(
    RefreshTokenCommandResponse RefreshToken,
    AccessTokenCommandResponse AccessToken);
