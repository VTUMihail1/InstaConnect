namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class DeleteUserCommandRequestBuilderFactory
{
    public DeleteUserCommandRequestBuilder Create(User user)
    {
        return new(user);
    }
}
