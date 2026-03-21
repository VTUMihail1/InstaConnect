using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Responses;

public record UserClaimIdApiResponse(string Id, ApplicationClaims Claim);
