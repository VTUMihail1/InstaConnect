namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostQueryRepository
{
	public Task<ICollection<PostResponse>> GetAllAsync(
        PostsFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsSortingQuery sorting,
        PostsPaginationQuery pagination,
        CancellationToken cancellationToken);

	public Task<ICollection<PostResponse>> GetAllForUserAsync(
        PostsForUserFilterQuery filter,
        CurrentUserQuery currentUser,
        PostsForUserSortingQuery sorting,
        PostsPaginationQuery pagination,
        CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
        PostsFilterQuery filter,
        CancellationToken cancellationToken);

    public Task<long> GetTotalCountForUserAsync(
        PostsForUserFilterQuery filter,
        CancellationToken cancellationToken);

    public Task<PostResponse?> GetByIdAsync(
        PostId id,
        CurrentUserQuery currentUser,
        CancellationToken cancellationToken);

    public Task<bool> ExistsByIdAsync(
        PostId id,
        CancellationToken cancellationToken);
}
