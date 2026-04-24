using InstaConnect.Common.Events.Features.Tokens.Models;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Bodies;

public record AddUserClaimApiBody(ApplicationClaims Claim = UserClaimDefaultValues.Claim);
