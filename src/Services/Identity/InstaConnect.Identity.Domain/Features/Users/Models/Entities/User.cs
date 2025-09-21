using InstaConnect.Common.Extensions;
using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Entities;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Users.Models.Entities;

public class User : IEntity
{
    private User()
    {
        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Name = string.Empty;
        PasswordHash = string.Empty;
        IsEmailConfirmed = false;
        Claims = [];
        RefreshTokens = [];
        EmailConfirmationTokens = [];
        ForgotPasswordTokens = [];
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
        Claims = [];
        RefreshTokens = [];
        EmailConfirmationTokens = [];
        ForgotPasswordTokens = [];
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
        ICollection<UserClaim> claims,
        ICollection<RefreshToken> refreshTokens,
        ICollection<EmailConfirmationToken> emailConfirmationTokens,
        ICollection<ForgotPasswordToken> forgotPasswordTokens)
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
        Claims = claims;
        RefreshTokens = refreshTokens;
        EmailConfirmationTokens = emailConfirmationTokens;
        ForgotPasswordTokens = forgotPasswordTokens;
    }

    public string Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Name { get; private set; }

    public string PasswordHash { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    public string? ProfileImage { get; private set; }

    public ICollection<UserClaim> Claims { get; }

    public ICollection<RefreshToken> RefreshTokens { get; }

    public ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

    public ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; }

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


