using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Entitites;
using InstaConnect.Identity.Domain.Features.UserClaims.Models.Entitites;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Identity.Domain.Features.Users.Models.Entitites;

public class User : BaseEntity
{
    public User(
        string firstName,
        string lastName,
        string email,
        string userName,
        string passwordHash,
        string? profileImage)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        PasswordHash = passwordHash;
        ProfileImage = profileImage;
    }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public string? ProfileImage { get; set; }

    public bool IsEmailConfirmed { get; set; }

    public ICollection<ForgotPasswordToken> ForgotPasswordTokens { get; set; } = [];

    public ICollection<EmailConfirmationToken> EmailConfirmationTokens { get; set; } = [];

    public ICollection<UserClaim> UserClaims { get; set; } = [];
}


