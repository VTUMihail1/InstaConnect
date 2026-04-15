namespace InstaConnect.Identity.Domain.Features.Users.Abstractions;

public interface IUserCommandRepository
{
    Task<User?> GetByIdAsync(
        UserId id,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

    Task<bool> ExistsByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken);

    Task<bool> IsNameUniqueAsync(
        Name name,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        UserInclude? include,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken);

    Task<bool> IsEmailUniqueAsync(
        Email email,
        CancellationToken cancellationToken);

    Task AddAsync(User entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken);

    Task DeleteAsync(User entity, CancellationToken cancellationToken);

    Task UpdateAsync(User entity, CancellationToken cancellationToken);
}
