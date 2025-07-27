using InstaConnect.PostLikes.Domain.Features.PostLikeComments.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikeLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.Users.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Users.Models.Entities;

using System.Security.Principal;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

public class PostLike : IEntity
{
    private PostLike()
    {
        Id = string.Empty;
        PostId = string.Empty;
        UserId = string.Empty;
    }

    public PostLike(
        string id,
        string postId,
        string userId,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        PostId = postId;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public PostLike(
        string id,
        Post post,
        User user,
        DateTimeOffset createdAt,
        DateTimeOffset updatedAt)
    {
        Id = id;
        Post = post;
        User = user;
        PostId = post.Id;
        UserId = user.Id;
    }

    public string Id { get; }

    public string PostId { get; }

    public string UserId { get; }

    public Post? Post { get; }

    public User? User { get; }

    public DateTimeOffset CreatedAt { get; }

    public DateTimeOffset UpdatedAt { get; }
}
