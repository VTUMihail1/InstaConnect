namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserDeletedEventRequestBuilder
{
    private string _id;

    public UserDeletedEventRequestBuilder(User user)
    {
        _id = user.Id;
    }

    public UserDeletedEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UserDeletedEventRequest Build()
    {
        return new(_id);
    }
}
