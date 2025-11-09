using InstaConnect.Posts.Tests.Features.Users.Utilities;

namespace InstaConnect.Posts.Tests.Features.Users.Builders;

public class UserBuilder
{
    private readonly ObjectBuilder<User> _objectBuilder;

    public UserBuilder(ObjectBuilder<User> objectBuilder)
    {
        _objectBuilder = objectBuilder;

        WithId(UserDataFaker.GetId());
        WithName(UserDataFaker.GetName());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithProfileImage(UserDataFaker.GetProfileImage());
        WithCreatedAt(UserDataFaker.GetCreatedAt());
        WithUpdatedAt(UserDataFaker.GetUpdatedAt());
    }

    public UserBuilder WithId(string id, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Id, id, transformer);

        return this;
    }

    public UserBuilder WithName(string name, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Name, name, transformer);

        return this;
    }

    public UserBuilder WithFirstName(string firstName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.FirstName, firstName, transformer);

        return this;
    }

    public UserBuilder WithLastName(string lastName, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.LastName, lastName, transformer);

        return this;
    }

    public UserBuilder WithEmail(string email, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.Email, email, transformer);

        return this;
    }

    public UserBuilder WithProfileImage(string? profileImage, IStringTransformer? transformer = null)
    {
        _objectBuilder.WithString(p => p.ProfileImage, profileImage, transformer);

        return this;
    }

    public UserBuilder WithCreatedAt(DateTimeOffset createdAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.CreatedAt, createdAt, transformer);

        return this;
    }

    public UserBuilder WithUpdatedAt(DateTimeOffset updatedAt, IDateTimeOffsetTransformer? transformer = null)
    {
        _objectBuilder.WithDateTimeOffset(p => p.UpdatedAt, updatedAt, transformer);

        return this;
    }

    public User Build()
    {
        return _objectBuilder.Build();
    }
}
