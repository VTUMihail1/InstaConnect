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
        PostId id,
        PostIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(
        PostId id,
        CancellationToken cancellationToken);

    Task AddAsync(Post entity, CancellationToken cancellationToken);

    Task UpdateAsync(Post entity, CancellationToken cancellationToken);

    Task DeleteAsync(Post entity, CancellationToken cancellationToken);
}
