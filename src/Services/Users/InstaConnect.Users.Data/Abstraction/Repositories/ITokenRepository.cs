using InstaConnect.Shared.Data.Repositories.Abstract;
using InstaConnect.Users.Data.Models.Entities;

namespace InstaConnect.Users.Data.Abstraction.Repositories;

/// <summary>
/// Represents a repository interface specifically for managing tokens, inheriting from the generic repository for entities of type <see cref="Token"/>.
/// </summary>
public interface ITokenRepository : IBaseRepository<Token>
{
    Task<Token?> GetByValueAsync(string value, CancellationToken cancellationToken);
}
