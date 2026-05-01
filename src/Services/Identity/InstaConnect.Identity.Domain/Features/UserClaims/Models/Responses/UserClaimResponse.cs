namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Responses;

public record UserClaimResponse(
	UserClaimId Id,
	UserResponse? User,
	DateTimeOffset CreatedAtUtc) : IEntityResponse;
