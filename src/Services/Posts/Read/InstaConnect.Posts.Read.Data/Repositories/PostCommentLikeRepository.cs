﻿using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Read.Data.Repositories;

public class PostCommentLikeRepository : BaseReadRepository<PostCommentLike>, IPostCommentLikeRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentLikeRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }

    public virtual async Task<PostCommentLike?> GetByUserIdAndPostCommentIdAsync(string userId, string postCommentId, CancellationToken cancellationToken)
    {
        var postCommentLike =
        await IncludeProperties(
            _postsContext.PostCommentLikes)
            .FirstOrDefaultAsync(pl => pl.UserId == userId && pl.PostCommentId == postCommentId);

        return postCommentLike;
    }
}