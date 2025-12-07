namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserDeletedEventRequestBuilder
{
    private string _id;

    public UserDeletedEventRequestBuilder(User user)
    {
        _id = user.Id.Id;
    }

    public UserDeletedEventRequestBuilder WithId(User user, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public UserDeletedEventRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public UserDeletedEventRequest Build()
    {
        return new(_id);
    }
}
