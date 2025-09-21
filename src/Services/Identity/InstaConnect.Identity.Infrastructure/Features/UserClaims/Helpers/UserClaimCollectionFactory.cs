using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Identity.Infrastructure.Features.UserClaims.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Responses;

namespace InstaConnect.UserClaims.Infrastructure.Features.UserClaims.Helpers;

internal class UserClaimCollectionFactory : IUserClaimCollectionFactory
{
    public UserClaimCollection Create(ICollection<UserClaim> userClaims)
    {
        return new UserClaimCollection(userClaims);
    }
}
