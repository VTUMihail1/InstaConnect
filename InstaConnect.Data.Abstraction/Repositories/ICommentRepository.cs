using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing comments, inheriting from the generic repository for entities of type <see cref="Comment"/>.
    /// </summary>
    public interface ICommentRepository : IRepository<Comment>
    {
        // This interface inherits CRUD (Create, Read, Update, Delete) operations
        // from IRepository<Comment>. You can add additional methods specific to comment management here if needed.
    }
}
