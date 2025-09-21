using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
internal interface IUserClaimCollectionFactory
{
    UserClaimCollection Create(ICollection<UserClaim> userClaims);
}
