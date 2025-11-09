namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeFactory
{
    public PostLike Create(string id, string userId);
}
