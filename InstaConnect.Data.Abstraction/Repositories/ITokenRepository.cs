using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing tokens, inheriting from the generic repository for entities of type <see cref="Token"/>.
    /// </summary>
    public interface ITokenRepository : IRepository<Token>
    {
        // This interface inherits CRUD (Create, Read, Update, Delete) operations
        // from IRepository<Token>. You can add additional methods specific to token management here if needed.
    }
}
