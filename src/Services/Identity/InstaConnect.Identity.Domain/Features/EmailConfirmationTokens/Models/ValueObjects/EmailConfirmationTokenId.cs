namespace InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.ValueObjects;

public record EmailConfirmationTokenId(UserId Id, string Value) : IEntityId;
