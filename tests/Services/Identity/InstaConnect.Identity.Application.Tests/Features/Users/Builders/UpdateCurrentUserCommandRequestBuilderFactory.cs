namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class UpdateCurrentUserCommandRequestBuilderFactory
{
    public UpdateCurrentUserCommandRequestBuilder Create(User user)
    {
        return new(user);
    }
}
