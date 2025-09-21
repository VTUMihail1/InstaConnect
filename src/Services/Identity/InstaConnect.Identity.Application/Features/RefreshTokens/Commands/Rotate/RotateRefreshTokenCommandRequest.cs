using Microsoft.AspNetCore.Http;

namespace InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Add;

public record RotateRefreshTokenCommandRequest(
    string Id,
    string Value) : ICommandRequest<RotateRefreshTokenCommandResponse>;
