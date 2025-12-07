namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;

public record IssueRefreshTokenCommandRequest(
    string Name,
    string Password) : ICommandRequest<IssueRefreshTokenCommandResponse>;
