namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserDeletedEventRequestBuilder
{
    private readonly ObjectBuilder<UserDeletedEventRequest> _objectBuilder;

    public UserDeletedEventRequestBuilder(ObjectBuilder<UserDeletedEventRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(user.Id);
    }

    public UserDeletedEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public UserDeletedEventRequest Build()
    {
        return _objectBuilder.Build();
    }
}
