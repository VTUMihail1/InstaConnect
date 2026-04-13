using InstaConnect.Identity.Tests.Features.Users.Utilities;

namespace InstaConnect.Identity.Tests.Features.Users.Builders;

public class UserBuilder
{
    private string _id;
    private string _name;
    private string _firstName;
    private string _lastName;
    private string _email;
    private bool _isEmailConfirmed;
    private string _passwordHash;
    private string? _profileImage;
    private DateTimeOffset _createdAtUtc;
    private DateTimeOffset _updatedAtUtc;

    public UserBuilder(string passwordHash, string? profileImage)
    {
        _id = UserDataFaker.GetId();
        _name = UserDataFaker.GetName();
        _firstName = UserDataFaker.GetFirstName();
        _lastName = UserDataFaker.GetLastName();
        _email = UserDataFaker.GetEmail();
        _isEmailConfirmed = UserDataFaker.GetIsEmailConfirmed();
        _passwordHash = passwordHash;
        _profileImage = profileImage;
        _createdAtUtc = UserDataFaker.GetCreatedAtUtc();
        _updatedAtUtc = UserDataFaker.GetUpdatedAtUtc();
    }

    public UserBuilder WithPasswordHash(string passwordHash)
    {
        _passwordHash = passwordHash;

        return this;
    }

    public UserBuilder WithConfirmedEmail()
    {
        _isEmailConfirmed = true;

        return this;
    }

    public UserBuilder WithUnconfirmedEmail()
    {
        _isEmailConfirmed = false;

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
            _passwordHash,
            _isEmailConfirmed,
            new(_profileImage),
            _createdAtUtc,
            _updatedAtUtc);
    }
}
