namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

public record RotateRefreshTokenCommandRequest(string Id, string Value) : ICommandRequest<RotateRefreshTokenCommandResponse>;
