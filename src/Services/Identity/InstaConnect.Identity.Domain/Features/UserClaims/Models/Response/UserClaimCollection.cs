using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

namespace InstaConnect.Users.Domain.Features.Users.Models.Responses;
public record UserClaimCollection(ICollection<UserClaim> Data);
