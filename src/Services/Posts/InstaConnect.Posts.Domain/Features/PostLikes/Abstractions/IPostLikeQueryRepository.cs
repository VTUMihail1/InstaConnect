namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeQueryRepository
{
	public Task<ICollection<PostLikeResponse>> GetAllAsync(
		PostLikesFilterQuery filter,
		CurrentUserQuery currentUser,
		PostLikesSortingQuery sorting,
		PostLikesPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		PostLikesFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<ICollection<PostLikeResponse>> GetAllForUserAsync(
		PostLikesForUserFilterQuery filter,
		CurrentUserQuery currentUser,
		PostLikesForUserSortingQuery sorting,
		PostLikesPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountForUserAsync(
		PostLikesForUserFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<PostLikeResponse?> GetByIdAsync(
		PostLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		PostLikeId id,
		CancellationToken cancellationToken);
}
