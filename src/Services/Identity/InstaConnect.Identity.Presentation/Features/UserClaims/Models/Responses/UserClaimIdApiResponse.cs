using InstaConnect.Common.Events.Models;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Responses;

public record UserClaimIdApiResponse(string Id, ApplicationClaims Claim);
