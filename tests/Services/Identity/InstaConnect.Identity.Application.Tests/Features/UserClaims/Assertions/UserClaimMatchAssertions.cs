using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Application.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
    extension(AddUserClaimCommandResponse response)
    {
        public void ShouldSatisfy(UserClaim userClaim, AddUserClaimCommandRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(userClaim, request));
        }
    }

    extension(GetAllUserClaimsQueryResponse response)
    {
        public void ShouldSatisfy(
            User user,
            ICollection<UserClaim> userClaims,
            GetAllUserClaimsQueryRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, userClaims, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<UserClaim> userClaims,
            GetAllUserClaimsQueryRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, userClaims, request, termTransformer));
        }
    }

    extension(UserClaim userClaim)
    {
        public void ShouldSatisfy(AddUserClaimCommandRequest request)
        {
            userClaim.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
