namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class DeleteCurrentUserCommandRequestBuilderFactory
{
    public DeleteCurrentUserCommandRequestBuilder Create(User user)
    {
        return new(user);
    }
}
