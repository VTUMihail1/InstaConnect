namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;

public class DeleteUserClaimCommandRequestBuilderFactory
{
    public DeleteUserClaimCommandRequestBuilder Create(UserClaim userClaim)
    {
        return new(userClaim);
    }
}
