using Microsoft.AspNetCore.Http;

namespace InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Add;

public record IssueRefreshTokenCommandRequest(
    string Name,
    string Password) : ICommandRequest<IssueRefreshTokenCommandResponse>;
