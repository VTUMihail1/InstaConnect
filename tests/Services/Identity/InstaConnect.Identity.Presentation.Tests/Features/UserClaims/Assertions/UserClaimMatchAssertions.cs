using InstaConnect.Common.Tests.DataAttributes.Enums.Sort;
using InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Utilities;

namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Assertions;

public static class UserClaimMatchAssertions
{
    extension(AddUserClaimApiResponse response)
    {
        public void ShouldSatisfy(
        UserClaim userClaim,
        AddUserClaimApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(userClaim, request));
        }
    }

    extension(GetAllUserClaimsApiResponse response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<UserClaim> userClaims,
        GetAllUserClaimsApiRequest request)
        {
            response.ShouldSatisfy(p => p.Matches(user, userClaims, request));
        }

        public void ShouldSatisfy(
            User user,
            ICollection<UserClaim> userClaims,
            GetAllUserClaimsApiRequest request,
            ISortEnumTermTransformer<UserClaim> termTransformer)
        {
            response.ShouldSatisfy(p => p.Matches(user, userClaims, request, termTransformer));
        }
    }

    extension(ActionResult<AddUserClaimApiResponse> response)
    {
        public void ShouldSatisfy(
        UserClaim userClaim,
        AddUserClaimApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(userClaim, request));
        }
    }

    extension(ActionResult<GetAllUserClaimsApiResponse> response)
    {
        public void ShouldSatisfy(
        User user,
        ICollection<UserClaim> userClaims,
        GetAllUserClaimsApiRequest request)
        {
            response.ShouldBeActionResultAndSatisfy(p => p.Matches(user, userClaims, request));
        }
    }

    extension(UserClaim userClaim)
    {
        public void ShouldSatisfy(AddUserClaimApiRequest request)
        {
            userClaim.ShouldSatisfy(p => p.Matches(request));
        }
    }
}
