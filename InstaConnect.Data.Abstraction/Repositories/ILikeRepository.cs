using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing likes, inheriting from the generic repository for entities of type <see cref="Like"/>.
    /// </summary>
    public interface ILikeRepository : IRepository<Like>
    {
        // This interface inherits CRUD (Create, Read, Update, Delete) operations
        // from IRepository<Like>. You can add additional methods specific to like management here if needed.
    }
}
