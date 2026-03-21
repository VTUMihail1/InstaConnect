namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserQueryRepository
{
    Task<ICollection<UserResponse>> GetAllAsync(
        UsersFilterQuery filter,
        CurrentUserQuery current,
        UsersSortingQuery sorting,
        UsersPaginationQuery pagination,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<UserResponse>> GetAllAsync(
        UsersFilterQuery filter,
        CurrentUserQuery current,
        UsersSortingQuery sorting,
        UsersPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        UsersFilterQuery filter,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        UsersFilterQuery filter,
        CancellationToken cancellationToken);

    Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery current,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<UserResponse?> GetByIdAsync(
        UserId id,
        CurrentUserQuery current,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken);
}
