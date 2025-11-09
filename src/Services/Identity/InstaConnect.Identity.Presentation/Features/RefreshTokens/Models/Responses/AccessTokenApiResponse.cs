namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Responses;

public record AccessTokenApiResponse(string Id, string Value, DateTimeOffset ExpiresAt);
