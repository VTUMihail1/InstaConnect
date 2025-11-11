using InstaConnect.Common.Tests.DataAttributes.Base;
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
    private DateTimeOffset _createdAt;
    private DateTimeOffset _updatedAt;

    public UserBuilder()
    {
        _id = UserDataFaker.GetId();
        _name = UserDataFaker.GetName();
        _firstName = UserDataFaker.GetFirstName();
        _lastName = UserDataFaker.GetLastName();
        _email = UserDataFaker.GetEmail();
        _profileImage = UserDataFaker.GetProfileImage();
        _createdAt = UserDataFaker.GetCreatedAt();
        _updatedAt = UserDataFaker.GetUpdatedAt();
    }

    public UserBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _id = transformer.TryTransform(id);

        return this;
    }

    public UserBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _name = transformer.TryTransform(name);

        return this;
    }

    public UserBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _firstName = transformer.TryTransform(firstName);

        return this;
    }

    public UserBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _lastName = transformer.TryTransform(lastName);

        return this;
    }

    public UserBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _email = transformer.TryTransform(email);

        return this;
    }

    public UserBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _profileImage = transformer.TryTransform(profileImage!);

        return this;
    }

    public UserBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _createdAt = transformer.TryTransform(createdAt);

        return this;
    }

    public UserBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _updatedAt = transformer.TryTransform(updatedAt);

        return this;
    }

    public User Build()
    {
        return new(_id, _name, _firstName, _lastName, _email, _profileImage, _createdAt, _updatedAt);
    }
}
