using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing comment likes, inheriting from the generic repository for entities of type <see cref="CommentLike"/>.
    /// </summary>
    public interface ICommentLikeRepository : IRepository<CommentLike>
    {
        // This interface inherits CRUD (Create, Read, Update, Delete) operations
        // from IRepository<CommentLike>. You can add additional methods specific to comment like management here if needed.
    }
}
