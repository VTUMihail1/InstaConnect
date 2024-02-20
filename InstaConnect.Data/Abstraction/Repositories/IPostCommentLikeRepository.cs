using InstaConnect.Data.Abstraction.Repositories.Base;
using InstaConnect.Data.Models.Entities;

namespace InstaConnect.Data.Abstraction.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing post comment likes, inheriting from the generic repository for entities of type <see cref="PostCommentLike"/>.
    /// </summary>
    public interface IPostCommentLikeRepository : IRepository<PostCommentLike>
    { }

}
