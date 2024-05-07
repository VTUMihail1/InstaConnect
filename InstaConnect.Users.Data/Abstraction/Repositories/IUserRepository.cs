using InstaConnect.Shared.Data.Repositories.Abstract;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Data.Abstraction.Repositories;

/// <summary>
/// Represents a repository interface specifically for managing users, inheriting from the generic repository for entities of type <see cref="User"/>.
/// </summary>
public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<User?> GetByNameAsync(string name, CancellationToken cancellationToken);
}
