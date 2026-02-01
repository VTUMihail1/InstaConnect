namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(
        UserId id,
        UserInclude include,
        CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        UserInclude include,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        UserInclude include,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken);

    Task AddAsync(User entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken);

    Task DeleteAsync(User entity, CancellationToken cancellationToken);

    Task UpdateAsync(User entity, CancellationToken cancellationToken);
}
