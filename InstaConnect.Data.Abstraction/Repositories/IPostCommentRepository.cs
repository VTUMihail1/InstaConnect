using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing post comments, inheriting from the generic repository for entities of type <see cref="PostComment"/>.
    /// </summary>
    public interface IPostCommentRepository : IRepository<PostComment>
    { }
}
