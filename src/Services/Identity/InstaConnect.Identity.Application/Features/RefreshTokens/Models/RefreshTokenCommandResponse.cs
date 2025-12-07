namespace InstaConnect.Identity.Application.Features.RefreshTokens.Models;

public record RefreshTokenCommandResponse(RefreshTokenIdCommandResponse Id, AccessTokenCommandResponse AccessToken, DateTimeOffset ExpiresAt);


