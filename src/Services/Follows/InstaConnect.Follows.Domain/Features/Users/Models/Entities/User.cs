using InstaConnect.Follows.Domain.Features.Follows.Models.Entities;
using InstaConnect.Shared.Domain.Abstractions;

namespace InstaConnect.Follows.Domain.Features.Users.Models.Entities;

public class User : IBaseEntity, IAuditableInfo
{
    private User()
    {
        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        UserName = string.Empty;
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string userName,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string userName,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt,
        ICollection<Follow> followers,
        ICollection<Follow> followings)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Followers = followers;
        Followings = followings;
    }

    public string Id { get; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string? ProfileImage { get; set; }

    public ICollection<Follow> Followers { get; set; } = [];

    public ICollection<Follow> Followings { get; set; } = [];

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}


