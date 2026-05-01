using InstaConnect.Identity.Presentation.Features.Users.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.Users.Models.Requests;

public record GetUserDetailsByIdApiRequest(
	[FromRoute] string Id,
	[UserIdFromClaim] string CurrentId) : ICurrentUserableApiRequest;
