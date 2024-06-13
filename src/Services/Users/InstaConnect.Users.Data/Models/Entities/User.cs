using InstaConnect.Shared.Data.Models.Base;
using Microsoft.AspNetCore.Identity;

namespace InstaConnect.Users.Data.Models.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string PasswordHash { get; set; }

    public bool IsEmailConfirmed { get; set; }

    public ICollection<Token> Tokens { get; set; } = new List<Token>();

    public ICollection<UserClaim> UserClaims { get; set; } = new List<UserClaim>();
}


