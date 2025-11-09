namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserAddedEventRequestBuilder
{
    private readonly ObjectBuilder<UserAddedEventRequest> _objectBuilder;

    public UserAddedEventRequestBuilder(ObjectBuilder<UserAddedEventRequest> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(UserDataFaker.GetId());
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
    }

    public UserAddedEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public UserAddedEventRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Name, name, transformer);

        return this;
    }

    public UserAddedEventRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.FirstName, firstName, transformer);

        return this;

    }

    public UserAddedEventRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.LastName, lastName, transformer);

        return this;
    }

    public UserAddedEventRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Email, email, transformer);

        return this;
    }

    public UserAddedEventRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public UserAddedEventRequest Build()
    {
        return _objectBuilder.Build();
    }
}
