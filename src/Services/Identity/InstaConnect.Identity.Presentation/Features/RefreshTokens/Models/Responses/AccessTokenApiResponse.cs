namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;

public record AccessTokenApiResponse(string Id, string Value, DateTimeOffset ExpiresAt);
