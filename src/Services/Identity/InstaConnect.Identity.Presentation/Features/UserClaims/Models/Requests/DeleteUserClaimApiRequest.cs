using InstaConnect.Common.Events.Models;

namespace InstaConnect.Identity.Presentation.Features.UserClaims.Models.Requests;

public record DeleteUserClaimApiRequest(
    [FromRoute] string Id,
    [FromRoute] ApplicationClaims Claim = UserClaimDefaultValues.Claim);
