namespace InstaConnect.ForgotPasswordTokens.Infrastructure.Features.ForgotPasswordTokens.Models;

public record ForgotPasswordTokenQueryEntity(
        string Id,
        string Value,
        DateTimeOffset ExpiresAt,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt);
