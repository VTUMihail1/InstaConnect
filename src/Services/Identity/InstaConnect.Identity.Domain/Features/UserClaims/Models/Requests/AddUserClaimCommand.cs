using InstaConnect.Common.Domain.Utilities;

namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record AddUserClaimCommand(UserId Id, ApplicationClaims Claim);
