using InstaConnect.Common.Events.Features.Tokens.Models;

namespace InstaConnect.Identity.Application.Features.UserClaims.Models;

public record UserClaimIdCommandResponse(string Id, ApplicationClaims Claim);
