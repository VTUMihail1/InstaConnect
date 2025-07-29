using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

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
        Posts = [];
        PostLikes = [];
        PostComments = [];
        PostCommentLikes = [];
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
        Posts = [];
        PostLikes = [];
        PostComments = [];
        PostCommentLikes = [];
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
        ICollection<Post> posts,
        ICollection<PostLike> postLikes,
        ICollection<PostComment> postComments,
        ICollection<PostCommentLike> postCommentLikes)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Name = userName;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Posts = posts;
        PostLikes = postLikes;
        PostComments = postComments;
        PostCommentLikes = postCommentLikes;
    }

    public string Id { get; }

    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public string Email { get; }

    public string Name { get; private set; }

    public string? ProfileImage { get; private set; }

    public ICollection<Post> Posts { get; }

    public ICollection<PostLike> PostLikes { get; }

    public ICollection<PostComment> PostComments { get; }

    public ICollection<PostCommentLike> PostCommentLikes { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; private set; }

    public void Update(
        string firstName,
        string lastName,
        string name,
        string? profileImage,
        DateTimeOffset updatedAt)
    {
        FirstName = firstName;
        LastName = lastName;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAt = updatedAt;
    }
}


