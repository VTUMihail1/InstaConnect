namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentQueryRepository
{
	public Task<ICollection<PostCommentResponse>> GetAllAsync(
		PostCommentsFilterQuery filter,
		PostCommentsSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<ICollection<PostCommentResponse>> GetAllForUserAsync(
		PostCommentsForUserFilterQuery filter,
		PostCommentsForUserSortingQuery sorting,
		PostCommentsPaginationQuery pagination,
		CurrentUserQuery currentUser,
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
