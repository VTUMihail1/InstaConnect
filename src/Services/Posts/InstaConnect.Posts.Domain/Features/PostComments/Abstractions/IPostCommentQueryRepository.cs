namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentQueryRepository
{
	public Task<ICollection<PostCommentResponse>> GetAllAsync(
		PostCommentsFilterQuery filter,
		CurrentUserQuery currentUser,
		PostCommentsSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
		PostCommentsForUserFilterQuery filter,
		CurrentUserQuery currentUser,
		PostCommentsForUserSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		PostCommentsFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountForUserAsync(
		PostCommentsForUserFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<PostCommentResponse?> GetByIdAsync(
		PostCommentId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		PostCommentId id,
		CancellationToken cancellationToken);
}
