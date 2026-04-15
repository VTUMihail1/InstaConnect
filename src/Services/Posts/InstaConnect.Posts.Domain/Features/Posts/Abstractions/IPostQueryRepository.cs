namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostQueryRepository
{
    Task<ICollection<PostResponse>> GetAllAsync(
        PostsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsSortingQuery sorting,
        PostsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<ICollection<PostResponse>> GetAllForUserAsync(
        PostsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsForUserSortingQuery sorting,
        PostsPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        PostsFilterQuery filter,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountForUserAsync(
        PostsForUserFilterQuery filter,
        CancellationToken cancellationToken);

    Task<PostResponse?> GetByIdAsync(
        PostId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        PostId id,
        CancellationToken cancellationToken);
}
