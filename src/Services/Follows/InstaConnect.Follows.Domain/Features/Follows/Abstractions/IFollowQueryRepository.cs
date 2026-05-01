namespace InstaConnect.Follows.Domain.Features.Follows.Abstractions;

public interface IFollowQueryRepository
{
	public Task<ICollection<FollowResponse>> GetAllAsync(
		FollowsFilterQuery filter,
		CurrentUserQuery currentUser,
		FollowsSortingQuery sorting,
		FollowsPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<ICollection<FollowResponse>> GetAllForFollowingAsync(
		FollowsForFollowingFilterQuery filter,
		CurrentUserQuery currentUser,
		FollowsForFollowingSortingQuery sorting,
		FollowsPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		FollowsFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountForFollowingAsync(
		FollowsForFollowingFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<FollowResponse?> GetByIdAsync(
		FollowId id,
		CurrentUserQuery currentUser,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		FollowId id,
		CancellationToken cancellationToken);
}
