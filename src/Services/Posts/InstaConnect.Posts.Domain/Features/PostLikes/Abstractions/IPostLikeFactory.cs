using InstaConnect.Posts.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeFactory
{
    public PostLike Create(string postId, string userId);
}
