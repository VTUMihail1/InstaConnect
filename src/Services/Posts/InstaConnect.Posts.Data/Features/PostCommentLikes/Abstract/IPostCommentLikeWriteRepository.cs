﻿using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
public interface IPostCommentLikeWriteRepository
{
    void Add(PostCommentLike postCommentLike);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(PostCommentLike postCommentLike);
    Task<PostCommentLike?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken);
}
