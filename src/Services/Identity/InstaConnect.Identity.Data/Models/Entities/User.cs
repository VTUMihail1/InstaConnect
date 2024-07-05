using InstaConnect.Shared.Data.Models.Base;

namespace InstaConnect.Identity.Data.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string? ProfileImage { get; set; }

    public bool IsEmailConfirmed { get; set; } = false;

    public ICollection<Token> Tokens { get; set; } = [];

    public ICollection<UserClaim> UserClaims { get; set; } = [];
}


