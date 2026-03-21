namespace InstaConnect.Identity.Application.Tests.Features.UserClaims.Builders;

public class AddUserClaimCommandRequestBuilderFactory
{
    public AddUserClaimCommandRequestBuilder Create(User user)
    {
        return new(user);
    }
}
