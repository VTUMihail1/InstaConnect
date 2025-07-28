using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.PostLikeLikes.Domain.Features.PostLikeLikes.Abstractions;

public interface IPostLikeFactory
{
    public PostLike Create(string id, string userId);
}
