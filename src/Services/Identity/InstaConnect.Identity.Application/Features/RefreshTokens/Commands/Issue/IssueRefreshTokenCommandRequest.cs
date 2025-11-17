using InstaConnect.Common.Application.Models;

namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Issue;

public record IssueRefreshTokenCommandRequest(
    NamePayload Name,
    string Password) : ICommandRequest<IssueRefreshTokenCommandResponse>;
