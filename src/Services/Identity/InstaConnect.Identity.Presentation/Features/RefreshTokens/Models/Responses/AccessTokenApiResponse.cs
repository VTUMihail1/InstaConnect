namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Responses;

public record AccessTokenApiResponse(string Value, DateTimeOffset ExpiresAtUtc);


