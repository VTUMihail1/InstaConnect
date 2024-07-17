﻿using InstaConnect.Posts.Write.Data.Models.Entities;
using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Posts.Write.Data.Abstract;

/// <summary>
/// Represents a repository interface specifically for managing post comment likes, inheriting from the generic repository for entities of type <see cref="PostCommentLike"/>.
/// </summary>
public interface IPostCommentLikeRepository : IBaseReadRepository<PostCommentLike>
{
    Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken);
}
