using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Bodies;

public record AddUserClaimApiBody(ApplicationClaims Claim = UserClaimDefaultValues.Claim);
