﻿using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories.Abstract;

namespace InstaConnect.Posts.Data.Abstract.Repositories
{
    /// <summary>
    /// Represents a repository interface specifically for managing post comments, inheriting from the generic repository for entities of type <see cref="PostComment"/>.
    /// </summary>
    public interface IPostCommentRepository : IBaseRepository<PostComment>
    { }
}