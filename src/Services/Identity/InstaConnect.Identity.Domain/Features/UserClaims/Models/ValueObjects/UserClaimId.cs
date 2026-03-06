namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.ValueObjects;

public record UserClaimId(UserId Id, string Claim) : IEntityId;
