using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Shared.Domain.Models.Base;

namespace InstaConnect.Follows.Domain.Features.Users.Models.Entities;

public class User : BaseEntity
{
    public User(
        string firstName,
        string lastName,
        string email,
        string userName,
        string? profileImage = null)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
    }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string? ProfileImage { get; set; } = string.Empty;

    public ICollection<Follow> Followers { get; set; } = [];

    public ICollection<Follow> Followings { get; set; } = [];
}


