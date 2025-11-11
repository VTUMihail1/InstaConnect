namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserUpdatedEventRequestBuilder
{
    private string _id;
    private string _name;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string? _profileImage;

    public UserUpdatedEventRequestBuilder(User user)
    {
        _id = user.Id;
        _name = UserDataFaker.GetName();
        _firstName = UserDataFaker.GetFirstName();
        _lastName = UserDataFaker.GetLastName();
        _email = UserDataFaker.GetEmail();
        _profileImage = UserDataFaker.GetProfileImage();
    }

    public UserUpdatedEventRequestBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _name = transformer.TryTransform(name);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _firstName = transformer.TryTransform(firstName);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _lastName = transformer.TryTransform(lastName);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _email = transformer.TryTransform(email);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _profileImage = transformer.TryTransform(profileImage!);

        return this;
    }

    public UserUpdatedEventRequest Build()
    {
        return new UserUpdatedEventRequest(_id, _name, _email, _firstName, _lastName, _profileImage);
    }
}
