using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Read.Data.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing posts, inheriting from the generic repository for entities of type <see cref="Post"/>.
/// </summary>
public interface IPostRepository : IBaseReadRepository<Post>
{ }
