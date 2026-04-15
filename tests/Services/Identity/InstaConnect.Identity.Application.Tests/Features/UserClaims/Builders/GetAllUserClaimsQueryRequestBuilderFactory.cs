namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;

public class GetAllUserClaimsQueryRequestBuilderFactory
{
    public GetAllUserClaimsQueryRequestBuilder Create(UserClaim userClaim)
    {
        return new(userClaim);
    }
}
