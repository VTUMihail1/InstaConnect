namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;

public interface IPostCommentLikeQueryRepository
{
	public Task<ICollection<PostCommentLikeResponse>> GetAllAsync(
		PostCommentLikesFilterQuery filter,
		CurrentUserQuery currentUser,
		PostCommentLikesSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<ICollection<PostCommentLikeResponse>> GetAllForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		CurrentUserQuery currentUser,
		PostCommentLikesForUserSortingQuery sorting,
		PostCommentLikesPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		PostCommentLikesFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountForUserAsync(
		PostCommentLikesForUserFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<PostCommentLikeResponse?> GetByIdAsync(
		PostCommentLikeId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		PostCommentLikeId id,
		CancellationToken cancellationToken);
}
