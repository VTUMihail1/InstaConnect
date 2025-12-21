namespace InstaConnect.Identity.Domain.Features.Users.Models.Entities;

public class User : IEntityWithId<UserId>
{
    private User()
    {
        Id = new(string.Empty);
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = new(string.Empty);
        Name = new(string.Empty);
        PasswordHash = string.Empty;
        IsEmailConfirmed = false;
        Claims = [];
        RefreshTokens = [];
        ForgotPasswordTokens = [];
        EmailConfirmationTokens = [];
    }

    public User(
        UserId id,
        string firstName,
        string lastName,
        Email email,
        Name name,
        string passwordHash,
        bool isEmailConfirmed,
        Image? profileImage,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc)
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
        ForgotPasswordTokens = [];
        EmailConfirmationTokens = [];
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
    }

    public User(
        UserId id,
        string firstName,
        string lastName,
        Email email,
        Name name,
        string passwordHash,
        bool isEmailConfirmed,
        Image? profileImage,
        DateTimeOffset createdAtUtc,
        DateTimeOffset updatedAtUtc,
        ICollection<UserClaim> claims,
        ICollection<RefreshToken> refreshTokens,
        ICollection<ForgotPasswordToken> forgotPasswordTokens,
        ICollection<EmailConfirmationToken> emailConfirmationTokens)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        PasswordHash = passwordHash;
        IsEmailConfirmed = isEmailConfirmed;
        ProfileImage = profileImage;
        CreatedAtUtc = createdAtUtc;
        UpdatedAtUtc = updatedAtUtc;
        Claims = claims;
        RefreshTokens = refreshTokens;
        ForgotPasswordTokens = forgotPasswordTokens;
        EmailConfirmationTokens = emailConfirmationTokens;
    }

    public UserId Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public Email Email { get; private set; }

    public Name Name { get; private set; }

    public string PasswordHash { get; private set; }

    public bool IsEmailConfirmed { get; private set; }

    public Image? ProfileImage { get; private set; }

    public ICollection<UserClaim> Claims { get; }

    public ICollection<RefreshToken> RefreshTokens { get; }

    public ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; }

    public ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; }

    public DateTimeOffset CreatedAtUtc { get; }

    public DateTimeOffset UpdatedAtUtc { get; private set; }

    public void UpdateEmail(Email email)
    {
        Email = email;
        IsEmailConfirmed = false;
    }

    public void UpdateProfileImage(Image? profileImage)
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

    public void Update(
        string firstName,
        string lastName,
        Name name,
        DateTimeOffset updatedAtUtc)
    {
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        UpdatedAtUtc = updatedAtUtc;
    }
}


