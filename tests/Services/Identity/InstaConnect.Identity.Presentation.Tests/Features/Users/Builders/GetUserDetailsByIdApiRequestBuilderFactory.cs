namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class GetUserDetailsByIdApiRequestBuilderFactory
{
    public GetUserDetailsByIdApiRequestBuilder Create(User user)
    {
        return new(user);
    }
}
