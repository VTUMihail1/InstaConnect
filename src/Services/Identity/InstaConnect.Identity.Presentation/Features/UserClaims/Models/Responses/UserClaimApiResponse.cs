using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Responses;

public record UserClaimApiResponse(
	string Id,
	ApplicationClaims Claim,
	UserApiResponse? User,
	DateTimeOffset CreatedAtUtc);
