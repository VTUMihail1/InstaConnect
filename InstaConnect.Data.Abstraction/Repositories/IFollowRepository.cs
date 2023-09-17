using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing follows, inheriting from the generic repository for entities of type <see cref="Follow"/>.
    /// </summary>
    public interface IFollowRepository : IRepository<Follow>
    {
        // This interface inherits CRUD (Create, Read, Update, Delete) operations
        // from IRepository<Follow>. You can add additional methods specific to follow management here if needed.
    }
}
