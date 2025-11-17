namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserRepository
{
    Task<UserCollection> GetAllAsync(
        UserFilterQuery filter,
        UserSortingQuery sorting,
        UserPaginationQuery pagination,
        UserIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(
        UserId id,
        UserIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        UserIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        UserIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken);

    Task AddAsync(User entity, CancellationToken cancellationToken);

    Task UpdateAsync(User entity, CancellationToken cancellationToken);

    Task DeleteAsync(User entity, CancellationToken cancellationToken);
}
