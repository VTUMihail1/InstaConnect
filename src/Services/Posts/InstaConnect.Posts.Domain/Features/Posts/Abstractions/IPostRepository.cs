using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostRepository
{
    Task<PostCollection> GetAllAsync(
        PostFilterQuery filter,
        PostSortingQuery sorting,
        PostPaginationQuery pagination,
        PostIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(
        string id,
        PostIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken);

    Task AddAsync(Post entity, CancellationToken cancellationToken);

    Task UpdateAsync(Post entity, CancellationToken cancellationToken);

    Task DeleteAsync(Post entity, CancellationToken cancellationToken);
}
