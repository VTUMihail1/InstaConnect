namespace InstaConnect.Identity.Application.Tests.Features.Users.Builders;

public class GetCurrentUserByIdQueryRequestBuilderFactory
{
    public GetCurrentUserByIdQueryRequestBuilder Create(User user)
    {
        return new(user);
    }
}
