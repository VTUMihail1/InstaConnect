using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing posts, inheriting from the generic repository for entities of type <see cref="Post"/>.
    /// </summary>
    public interface IPostRepository : IRepository<Post>
    {
        // This interface inherits CRUD (Create, Read, Update, Delete) operations
        // from IRepository<Post>. You can add additional methods specific to post management here if needed.

        /// <summary>
        /// Retrieves all posts including related entities such as users, comments, and likes.
        /// </summary>
        /// <returns>A collection of posts with related entities included.</returns>
        Task<ICollection<Post>> GetAllIncludedAsync();
    }
}
