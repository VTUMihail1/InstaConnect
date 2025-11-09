using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Entities;

public class User : IEntity
{
    private readonly IList<UserClaim> _claims;
    private readonly IList<RefreshToken> _refreshTokens;
    private readonly IList<ForgotPasswordToken> _forgotPasswordTokens;
    private readonly IList<EmailConfirmationToken> _emailConfirmationTokens;

    private User()
    {
        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Name = string.Empty;
        PasswordHash = string.Empty;
        IsEmailConfirmed = false;
        _claims = [];
        _refreshTokens = [];
        _forgotPasswordTokens = [];
        _emailConfirmationTokens = [];
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string passwordHash,
        bool isEmailConfirmed,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        PasswordHash = passwordHash;
        IsEmailConfirmed = isEmailConfirmed;
        ProfileImage = profileImage;
        _claims = [];
        _refreshTokens = [];
        _forgotPasswordTokens = [];
        _emailConfirmationTokens = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string passwordHash,
        bool isEmailConfirmed,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt,
        IList<UserClaim> claims,
        IList<RefreshToken> refreshTokens,
        IList<ForgotPasswordToken> forgotPasswordTokens,
        IList<EmailConfirmationToken> emailConfirmationTokens)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        PasswordHash = passwordHash;
        IsEmailConfirmed = isEmailConfirmed;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        _claims = claims;
        _refreshTokens = refreshTokens;
        _forgotPasswordTokens = forgotPasswordTokens;
        _emailConfirmationTokens = emailConfirmationTokens;
    }

    public string Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Name { get; private set; }

    public string PasswordHash { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    public string? ProfileImage { get; private set; }

    public IReadOnlyCollection<UserClaim> Claims => _claims.AsReadOnly();

    public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();

    public IReadOnlyCollection<EmailConfirmationToken> EmailConfirmationTokens => _emailConfirmationTokens.AsReadOnly();

    public IReadOnlyCollection<ForgotPasswordToken> ForgotPasswordTokens => _forgotPasswordTokens.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void UpdateEmail(string email)
    {
        Email = email;
        IsEmailConfirmed = false;
    }

    public void UpdateProfileImage(string? profileImage)
    {
        ProfileImage = profileImage;
    }

    public void ConfirmEmail()
    {
        IsEmailConfirmed = true;
    }

    public void UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
    }

    public bool HasEmail(string email)
    {
        var hasEmail = Email.EqualsOrdinalIgnoreCase(email);

        return hasEmail;
    }

    public bool DoesNotHaveEmail(string email)
    {
        var hasEmail = !HasEmail(email);

        return hasEmail;
    }

    public bool HasName(string name)
    {
        var hasName = Name.EqualsOrdinalIgnoreCase(name);

        return hasName;
    }

    public bool DoesNotHaveName(string name)
    {
        var hasName = !HasName(name);

        return hasName;
    }

    public void Update(
        string firstName,
        string lastName,
        string name,
        DateTimeOffset updatedAt)
    {
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        UpdatedAt = updatedAt;
    }
}


