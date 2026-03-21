namespace InstaConnect.Identity.Presentation.Tests.Features.Users.Builders;

public class UpdateCurrentUserApiRequestBuilderFactory
{
    public UpdateCurrentUserApiRequestBuilder Create(User user)
    {
        return new(user);
    }
}
