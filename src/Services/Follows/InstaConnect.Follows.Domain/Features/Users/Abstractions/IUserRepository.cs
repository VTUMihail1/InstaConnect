namespace InstaConnect.Follows.Domain.Features.Users.Abstractions;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(
        UserId id,
        CommonInclude<UserIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        CommonInclude<UserIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        CommonInclude<UserIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken);

    Task AddAsync(User entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken);

    Task DeleteAsync(User entity, CancellationToken cancellationToken);

    Task UpdateAsync(User entity, CancellationToken cancellationToken);
}
