namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Responses;
public record SessionToken(
    RefreshToken RefreshToken,
    AccessToken AccessToken);
