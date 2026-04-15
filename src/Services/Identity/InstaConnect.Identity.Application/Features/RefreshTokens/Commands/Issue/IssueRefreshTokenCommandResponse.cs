namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;

public record IssueRefreshTokenCommandResponse(
    RefreshTokenIdCommandResponse Id,
    AccessTokenCommandResponse AccessToken,
    DateTimeOffset ExpiresAtUtc);
