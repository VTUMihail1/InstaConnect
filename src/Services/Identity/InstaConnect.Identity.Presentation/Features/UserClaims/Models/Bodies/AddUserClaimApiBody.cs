using InstaConnect.Common.Events.Models;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Bodies;

public record AddUserClaimApiBody(ApplicationClaims Claim = UserClaimDefaultValues.Claim);
