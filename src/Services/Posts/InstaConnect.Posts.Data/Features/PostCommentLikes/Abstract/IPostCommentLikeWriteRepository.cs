﻿using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;

public interface IPostCommentLikeWriteRepository : IBaseWriteRepository<PostCommentLike>
{
    Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken);
}