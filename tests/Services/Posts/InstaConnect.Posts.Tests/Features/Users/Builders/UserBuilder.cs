using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.Builders;

public class UserBuilder
{
    private string _id;
    private string _name;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string? _profileImage;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

    public UserBuilder()
    {
        _id = UserDataFaker.GetId();
        _name = UserDataFaker.GetName();
        _firstName = UserDataFaker.GetFirstName();
        _lastName = UserDataFaker.GetLastName();
        _email = UserDataFaker.GetEmail();
        _profileImage = UserDataFaker.GetProfileImage();
        _createdAtUtc = UserDataFaker.GetCreatedAtUtc();
        _updatedAtUtc = UserDataFaker.GetUpdatedAtUtc();
    }

    public UserBuilder WithId(IStringTransformer transformer)
    {
        _id = transformer.Transform(_id);

        return this;
    }

    public UserBuilder WithName(IStringTransformer transformer)
    {
        _name = transformer.Transform(_name);

        return this;
    }

    public UserBuilder WithFirstName(IStringTransformer transformer)
    {
        _firstName = transformer.Transform(_firstName);

        return this;
    }

    public UserBuilder WithLastName(IStringTransformer transformer)
    {
        _lastName = transformer.Transform(_lastName);

        return this;
    }

    public UserBuilder WithEmail(IStringTransformer transformer)
    {
        _email = transformer.Transform(_email);

        return this;
    }

    public UserBuilder WithProfileImage(IStringTransformer transformer)
    {
        _profileImage = transformer.Transform(_profileImage ?? string.Empty);

        return this;
    }

    public UserBuilder WithCreatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _createdAtUtc = transformer.Transform(_createdAtUtc);

        return this;
    }

    public UserBuilder WithUpdatedAtUtc(IDateTimeOffsetTransformer transformer)
    {
        _updatedAtUtc = transformer.Transform(_updatedAtUtc);

        return this;
    }

    public User Build()
    {
        return new(
            new(_id),
            _firstName,
            _lastName,
            new(_email),
            new(_name),
            new(_profileImage),
            _createdAtUtc,
            _updatedAtUtc);
    }
}
