namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Rotate;

public record RotateRefreshTokenCommandRequest(RefreshTokenIdPayload Id) : ICommandRequest<RotateRefreshTokenCommandResponse>;
