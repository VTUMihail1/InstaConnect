namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserQueryRepository
{
	public Task<ICollection<UserResponse>> GetAllAsync(
		UsersFilterQuery filter,
		CurrentUserQuery current,
		UsersSortingQuery sorting,
		UsersPaginationQuery pagination,
		CancellationToken cancellationToken);

	public Task<long> GetTotalCountAsync(
		UsersFilterQuery filter,
		CancellationToken cancellationToken);

	public Task<UserResponse?> GetByIdAsync(
		UserId id,
		CurrentUserQuery current,
		CancellationToken cancellationToken);

	public Task<bool> ExistsByIdAsync(
		UserId id,
		CancellationToken cancellationToken);
}
