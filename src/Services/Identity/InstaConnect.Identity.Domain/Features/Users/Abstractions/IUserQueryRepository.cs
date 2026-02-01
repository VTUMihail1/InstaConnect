namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserQueryRepository
{
    Task<ICollection<UserResponse>> GetAllAsync(
        UserFilterQuery filter,
        CurrentUserQuery current,
        UserSortingQuery sorting,
        UserPaginationQuery pagination,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<ICollection<UserResponse>> GetAllAsync(
        UserFilterQuery filter,
        CurrentUserQuery current,
        UserSortingQuery sorting,
        UserPaginationQuery pagination,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        UserFilterQuery filter,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<long> GetTotalCountAsync(
        UserFilterQuery filter,
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
}
