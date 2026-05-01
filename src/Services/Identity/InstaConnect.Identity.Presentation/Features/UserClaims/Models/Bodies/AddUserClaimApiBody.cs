using InstaConnect.Common.Events.Features.AccessTokens.Models;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Bodies;

public record AddUserClaimApiBody(ApplicationClaims Claim = UserClaimDefaultValues.Claim);
