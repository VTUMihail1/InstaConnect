using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;

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

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string? ProfileImage { get; set; }

    public ICollection<Follow> Followers { get; set; } = [];

    public ICollection<Follow> Followings { get; set; } = [];
}


