namespace InstaConnect.Identity.Application.Features.RefreshTokens.Models;

public record RefreshTokenCommandResponse(RefreshTokenIdPayload Id, DateTimeOffset ExpiresAt);


