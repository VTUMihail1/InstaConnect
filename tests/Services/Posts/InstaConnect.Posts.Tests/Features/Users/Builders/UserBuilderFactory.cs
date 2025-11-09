namespace InstaConnect.Posts.Tests.Features.Users.Builders;

public class UserBuilderFactory
{
    private readonly ObjectBuilderFactory<User> _objectBuilderFactory = new();

    public UserBuilder Create()
    {
        var objectBuilder = _objectBuilderFactory.Create();
        var entityBuilder = new UserBuilder(objectBuilder);

        return entityBuilder;
    }
}
