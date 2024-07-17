using InstaConnect.Identity.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Identity.Data.Abstraction;

/// <summary>
/// Represents a repository interface specifically for managing users, inheriting from the generic repository for entities of type <see cref="User"/>.
/// </summary>
public interface IUserRepository : IBaseReadRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);

    Task ConfirmEmailAsync(string id, CancellationToken cancellationToken);

    Task ResetPasswordAsync(string id, string passwordHash, CancellationToken cancellationToken);
}
