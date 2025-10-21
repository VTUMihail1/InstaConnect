using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Responses;
using InstaConnect.Posts.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeRepository
{
    Task<PostLikeCollection> GetAllAsync(
        PostLikeFilterQuery filter,
        PostLikeSortingQuery sorting,
        PostLikePaginationQuery pagination,
        PostLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(
        string id,
        string userId,
        PostLikeIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<PostLike?> GetByIdAsync(
        string id,
        string userId,
        CancellationToken cancellationToken);

    Task AddAsync(PostLike entity, CancellationToken cancellationToken);

    Task UpdateAsync(PostLike entity, CancellationToken cancellationToken);

    Task DeleteAsync(PostLike entity, CancellationToken cancellationToken);
}
