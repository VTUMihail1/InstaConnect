using InstaConnect.Posts.Domain.Features.PostCommentLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entities;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Users.Models.Entities;

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
        ICollection<Post> posts,
        ICollection<PostLike> postLikes,
        ICollection<PostComment> postComments,
        ICollection<PostCommentLike> postCommentLikes)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserName = userName;
        ProfileImage = profileImage;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        Posts = posts;
        PostLikes = postLikes;
        PostComments = postComments;
        PostCommentLikes = postCommentLikes;
    }

    public string Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string UserName { get; set; }

    public string? ProfileImage { get; set; }

    public ICollection<Post> Posts { get; set; } = [];

    public ICollection<PostLike> PostLikes { get; set; } = [];

    public ICollection<PostComment> PostComments { get; set; } = [];

    public ICollection<PostCommentLike> PostCommentLikes { get; set; } = [];

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}


