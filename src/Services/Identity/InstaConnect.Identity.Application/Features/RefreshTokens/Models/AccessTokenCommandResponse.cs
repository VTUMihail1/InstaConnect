namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

public record AccessTokenCommandResponse(string Id, string Value, DateTimeOffset ExpiresAt);
