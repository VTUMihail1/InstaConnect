namespace InstaConnect.Posts.Presentation.Tests.Features.Users.Builders;

public class UserUpdatedEventRequestBuilder
{
    private string _id;
    private string _name;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string? _profileImage;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

    public UserUpdatedEventRequestBuilder(User user)
    {
        _id = user.Id.Id;
        _name = UserDataFaker.GetName();
        _firstName = UserDataFaker.GetFirstName();
        _lastName = UserDataFaker.GetLastName();
        _email = UserDataFaker.GetEmail();
        _profileImage = UserDataFaker.GetProfileImage();
        _createdAtUtc = user.CreatedAtUtc;
        _updatedAtUtc = UserDataFaker.GetUpdatedAtUtc();
    }

    public UserUpdatedEventRequestBuilder WithId(User user, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(user.Id.Id);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithName(User user, IStringTransformer? transformer = null)
    {
        _name = transformer.TryTransform(user.Name.Value);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithName(IStringTransformer transformer)
    {
        _name = transformer.Transform(_name);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithFirstName(IStringTransformer transformer)
    {
        _firstName = transformer.Transform(_firstName);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithLastName(IStringTransformer transformer)
    {
        _lastName = transformer.Transform(_lastName);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithEmail(User user, IStringTransformer? transformer = null)
    {
        _email = transformer.TryTransform(user.Email.Value);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithEmail(IStringTransformer transformer)
    {
        _email = transformer.Transform(_email);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithProfileImage(IStringTransformer transformer)
    {
        _profileImage = transformer.Transform(_profileImage ?? string.Empty);

        return this;
    }

    public UserUpdatedEventRequestBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _updatedAtUtc = transformer.Transform(_updatedAtUtc);

        return this;
    }

    public UserUpdatedEventRequest Build()
    {
        return new(new(_id, _name, _email, _firstName, _lastName, _profileImage, _createdAtUtc, _updatedAtUtc));
    }
}
