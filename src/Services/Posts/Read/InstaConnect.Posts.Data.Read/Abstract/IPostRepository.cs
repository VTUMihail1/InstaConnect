using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Data.Read.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing posts, inheriting from the generic repository for entities of type <see cref="Post"/>.
/// </summary>
public interface IPostRepository : IBaseRepository<Post>
{ }
