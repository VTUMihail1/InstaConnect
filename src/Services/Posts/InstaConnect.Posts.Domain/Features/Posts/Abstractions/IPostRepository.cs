using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostRepository
{
    Task<PostCollection> GetAllAsync(
        PostFilterQuery filter,
        CommonSortingQuery<PostSortProperty> sorting,
        CommonPaginationQuery pagination,
        CommonIncludeQuery<PostIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(
        PostId id,
        CommonIncludeQuery<PostIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(
        PostId id,
        CancellationToken cancellationToken);

    Task AddAsync(Post entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<Post> entities, CancellationToken cancellationToken);

    Task UpdateAsync(Post entity, CancellationToken cancellationToken);

    Task DeleteAsync(Post entity, CancellationToken cancellationToken);
}
