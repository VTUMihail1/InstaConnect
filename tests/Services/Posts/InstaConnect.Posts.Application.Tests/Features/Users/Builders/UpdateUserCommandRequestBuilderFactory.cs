namespace InstaConnect.Posts.Application.Tests.Features.Users.Builders;

public class UpdateUserCommandRequestBuilderFactory
{
    public UpdateUserCommandRequestBuilder Create(User user)
    {
        return new(user);
    }
}
