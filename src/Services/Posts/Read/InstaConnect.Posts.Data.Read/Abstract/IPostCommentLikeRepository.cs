﻿using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Data.Read.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing post comment likes, inheriting from the generic repository for entities of type <see cref="PostCommentLike"/>.
/// </summary>
public interface IPostCommentLikeRepository : IBaseRepository<PostCommentLike>
{
    Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken);
}
