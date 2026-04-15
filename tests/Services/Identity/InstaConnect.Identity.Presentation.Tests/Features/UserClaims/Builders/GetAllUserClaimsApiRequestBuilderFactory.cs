namespace InstaConnect.Identity.Presentation.Tests.Features.UserClaims.Builders;

public class GetAllUserClaimsApiRequestBuilderFactory
{
    public GetAllUserClaimsApiRequestBuilder Create(UserClaim userClaim)
    {
        return new(userClaim);
    }
}
