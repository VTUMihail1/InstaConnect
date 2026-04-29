using InstaConnect.Common.Events.Features.AccessTokens.Models;
using InstaConnect.Identity.Events.Features.Users;

namespace InstaConnect.Identity.Events.Features.UserClaims;

public record UserClaimEventRequest(
	string Id,
	ApplicationClaims Claim,
	UserEventRequest User,
	DateTimeOffset CreatedAtUtc);
