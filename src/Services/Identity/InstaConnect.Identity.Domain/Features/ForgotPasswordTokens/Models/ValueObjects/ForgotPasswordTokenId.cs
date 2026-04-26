namespace InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.ValueObjects;

public record ForgotPasswordTokenId(UserId Id, string Value) : IEntityId;
