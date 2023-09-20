using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing post likes, inheriting from the generic repository for entities of type <see cref="PostLike"/>.
    /// </summary>
    public interface IPostLikeRepository : IRepository<PostLike>
    {
        // This interface inherits CRUD (Create, Read, Update, Delete) operations
        // from IRepository<PostLike>. You can add additional methods specific to post like management here if needed.
    }
}
