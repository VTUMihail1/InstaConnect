namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;

public record RefreshTokenCommandResponse(string Id, string Value, DateTimeOffset ExpiresAt);


