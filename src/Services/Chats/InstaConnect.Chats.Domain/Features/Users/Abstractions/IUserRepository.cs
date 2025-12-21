using InstaConnect.Common.Domain.Models;

namespace InstaConnect.Chats.Domain.Features.Users.Abstractions;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(
        UserId id,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(
        UserId id,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        Name name,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        CommonIncludeQuery<UserIncludeProperty>? include,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        Email email,
        CancellationToken cancellationToken);

    Task AddAsync(User entity, CancellationToken cancellationToken);

    Task AddRangeAsync(IEnumerable<User> entities, CancellationToken cancellationToken);

    Task DeleteAsync(User entity, CancellationToken cancellationToken);

    Task UpdateAsync(User entity, CancellationToken cancellationToken);
}
