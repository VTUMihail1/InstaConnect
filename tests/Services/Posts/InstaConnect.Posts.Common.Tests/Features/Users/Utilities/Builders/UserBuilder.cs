using InstaConnect.Common.Tests.Utilities.Builders;
using InstaConnect.Common.Tests.Utilities.Variants.String;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
public class UserBuilder
{
    private readonly ObjectBuilder<User> _objectBuilder;

    public UserBuilder()
    {
        _objectBuilder = new ObjectBuilder<User>();

        WithId(UserDataFaker.GetId());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithName(UserDataFaker.GetName());
        WithProfileImage(UserDataFaker.GetProfileImage());
        WithCreatedAt(UserDataFaker.GetCreatedAt());
        WithUpdatedAt(UserDataFaker.GetUpdatedAt());
    }

    public UserBuilder WithId(string id, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Id, id, variant);

        return this;
    }

    public UserBuilder WithFirstName(string firstName, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.FirstName, firstName, variant);

        return this;
    }

    public UserBuilder WithLastName(string lastName, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.LastName, lastName, variant);

        return this;
    }

    public UserBuilder WithEmail(string email, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.Email, email, variant);

        return this;
    }

    public UserBuilder WithName(string userName, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.UserName, userName, variant);

        return this;
    }

    public UserBuilder WithProfileImage(string profileImage, StringVariantType type = StringVariantType.Default)
    {
        _objectBuilder.With(p => p.ProfileImage, profileImage, variant);

        return this;
    }

    public UserBuilder WithCreatedAt(DateTimeOffset createdAt)
    {
        _objectBuilder.With(p => p.CreatedAt, createdAt);

        return this;
    }

    public UserBuilder WithUpdatedAt(DateTimeOffset updatedAt)
    {
        _objectBuilder.With(p => p.UpdatedAt, updatedAt);

        return this;
    }

    public User Create()
    {
        return _objectBuilder.Create();
    }
}
