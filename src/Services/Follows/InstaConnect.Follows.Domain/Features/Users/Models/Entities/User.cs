using InstaConnect.Common.Domain.Extensions;

namespace InstaConnect.Follows.Domain.Features.Users.Models.Entities;

public class User : IEntity
{
    private readonly IList<Follow> _follows;

    private User()
    {
        Id = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
        Email = string.Empty;
        Name = string.Empty;
        _follows = [];
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        _follows = [];
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public User(
        string id,
        string firstName,
        string lastName,
        string email,
        string name,
        string? profileImage,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt,
        IList<Follow> follows)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = name;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        _follows = follows;
    }

    public string Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; private set; }

    public string Name { get; private set; }

    public string? ProfileImage { get; private set; }

    public IReadOnlyCollection<Follow> Follows => _follows.AsReadOnly();

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(
        string email,
        string firstName,
        string lastName,
        string name,
        string? profileImage,
        DateTimeOffset updatedAt)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAt = updatedAt;
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

    public void AddPost(Follow follow)
    {
        _follows.Add(follow);
    }
}


