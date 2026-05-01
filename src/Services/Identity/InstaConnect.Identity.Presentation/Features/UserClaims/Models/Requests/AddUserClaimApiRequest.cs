using InstaConnect.Identity.Presentation.Features.UserClaims.Models.Bodies;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;

public record AddUserClaimApiRequest(
	[FromRoute] string Id,
	[FromBody] AddUserClaimApiBody Body);
