using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Responses;

public record UserClaimIdApiResponse(string Id, ApplicationClaims Claim);
