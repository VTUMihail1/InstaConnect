namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetCurrentUserDetailsByIdApiRequestBuilderFactory
{
    public GetCurrentUserDetailsByIdApiRequestBuilder Create(User user)
    {
        return new(user);
    }
}
