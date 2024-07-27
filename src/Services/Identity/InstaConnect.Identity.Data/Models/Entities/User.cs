using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Models.Entities;

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

    public bool IsEmailConfirmed { get; set; } = false;

    public ICollection<Token> Tokens { get; set; } = [];

    public ICollection<UserClaim> UserClaims { get; set; } = [];
}


