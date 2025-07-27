using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeRepository
{
    Task<PostLikeCollection> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(string id, string postId, CancellationToken cancellationToken);

    void Add(PostLike postLike);

    void Update(PostLike postLike);

    void Delete(PostLike postLike);
}
