namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.ValueObjects;
public record RefreshTokenId(UserId Id, string Value) : IEntityId;
