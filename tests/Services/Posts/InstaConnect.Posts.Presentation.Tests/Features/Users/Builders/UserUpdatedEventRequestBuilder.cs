namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserUpdatedEventRequestBuilder
{
    private readonly ObjectBuilder<UserUpdatedEventRequest> _objectBuilder;

    public UserUpdatedEventRequestBuilder(ObjectBuilder<UserUpdatedEventRequest> objectBuilder, User user)
    {
        _objectBuilder = objectBuilder;

        WithId(user.Id);
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
    }

    public UserUpdatedEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Name, name, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.FirstName, firstName, transformer);

        return this;

    }

    public UserUpdatedEventRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.LastName, lastName, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Email, email, transformer);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public UserUpdatedEventRequest Build()
    {
        return _objectBuilder.Build();
    }
}
