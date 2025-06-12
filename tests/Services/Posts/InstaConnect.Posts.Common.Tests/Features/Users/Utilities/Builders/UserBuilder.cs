using InstaConnect.Common.Tests.Utilities.Builders;

namespace InstaConnect.Posts.Common.Tests.Features.Users.Utilities.Builders;
public class UserBuilder
{
    private readonly ObjectBuilder<User> _objectBuilder;

    public UserBuilder()
    {
        _objectBuilder = ObjectBuilderFactory.Build<User>();

        WithId(UserDataFaker.GetId());
        WithFirstName(UserDataFaker.GetFirstName());
        WithLastName(UserDataFaker.GetLastName());
        WithEmail(UserDataFaker.GetEmail());
        WithName(UserDataFaker.GetName());
        WithProfileImage(UserDataFaker.GetProfileImage());
        WithCreatedAt(UserDataFaker.GetCreatedAt());
        WithUpdatedAt(UserDataFaker.GetUpdatedAt());
    }

    public UserBuilder WithId(string id)
    {
        _objectBuilder.With(p => p.Id, id);

        return this;
    }

    public UserBuilder WithoutId()
    {
        _objectBuilder.Without(p => p.Id);

        return this;
    }

    public UserBuilder WithFirstName(string firstName)
    {
        _objectBuilder.With(p => p.FirstName, firstName);

        return this;
    }

    public UserBuilder WithoutFirstName()
    {
        _objectBuilder.Without(p => p.FirstName);

        return this;
    }

    public UserBuilder WithLastName(string lastName)
    {
        _objectBuilder.With(p => p.LastName, lastName);

        return this;
    }

    public UserBuilder WithoutLastName()
    {
        _objectBuilder.Without(p => p.LastName);

        return this;
    }

    public UserBuilder WithEmail(string email)
    {
        _objectBuilder.With(p => p.Email, email);

        return this;
    }

    public UserBuilder WithoutEmail()
    {
        _objectBuilder.Without(p => p.Email);

        return this;
    }

    public UserBuilder WithName(string userName)
    {
        _objectBuilder.With(p => p.UserName, userName);

        return this;
    }

    public UserBuilder WithoutUserName()
    {
        _objectBuilder.Without(p => p.UserName);

        return this;
    }

    public UserBuilder WithProfileImage(string? profileImage)
    {
        _objectBuilder.With(p => p.ProfileImage, profileImage);

        return this;
    }

    public UserBuilder WithoutProfileImage()
    {
        _objectBuilder.Without(p => p.ProfileImage);

        return this;
    }

    public UserBuilder WithCreatedAt(DateTimeOffset createdAt)
    {
        _objectBuilder.With(p => p.CreatedAt, createdAt);

        return this;
    }

    public UserBuilder WithoutCreatedAt()
    {
        _objectBuilder.Without(p => p.CreatedAt);

        return this;
    }

    public UserBuilder WithUpdatedAt(DateTimeOffset updatedAt)
    {
        _objectBuilder.With(p => p.UpdatedAt, updatedAt);

        return this;
    }

    public UserBuilder WithoutUpdatedAt()
    {
        _objectBuilder.Without(p => p.UpdatedAt);

        return this;
    }

    public User Create()
    {
        return _objectBuilder.Create();
    }
}
