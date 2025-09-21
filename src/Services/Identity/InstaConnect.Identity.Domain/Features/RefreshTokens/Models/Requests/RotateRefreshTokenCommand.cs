namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record RotateRefreshTokenCommand(string Id, string Value);
