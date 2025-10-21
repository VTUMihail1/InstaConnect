using InstaConnect.Posts.Domain.Features.Users.Models.Entities;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Posts.Domain.Features.Users.Abstractions;
public interface IUserRepository
{
    Task<User?> GetByIdAsync(
        string id,
        UserIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(
        string id,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        string name,
        UserIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(
        string name,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        string email,
        UserIncludeQuery? include,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken);

    Task AddAsync(User entity, CancellationToken cancellationToken);

    Task DeleteAsync(User entity, CancellationToken cancellationToken);

    Task UpdateAsync(User entity, CancellationToken cancellationToken);
}
