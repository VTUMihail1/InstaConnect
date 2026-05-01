namespace InstaConnect.Common.Application.Features.AccessTokens.Models;

public record AccessTokenCommandResponse(string Value, DateTimeOffset ExpiresAtUtc);
