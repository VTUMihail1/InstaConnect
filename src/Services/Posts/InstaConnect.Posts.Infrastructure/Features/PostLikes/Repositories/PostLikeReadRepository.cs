﻿using InstaConnect.Posts.Domain.Features.PostLikes.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;
using InstaConnect.Shared.Infrastructure.Extensions;

namespace InstaConnect.Posts.Infrastructure.Features.PostLikes.Repositories;

public class PostLikeReadRepository : IPostLikeReadRepository
{
    private readonly PostsContext _postsContext;

    public PostLikeReadRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<PaginationList<PostLike>> GetAllAsync(PostLikeCollectionReadQuery query, CancellationToken cancellationToken)
    {
        var postLikes = await _postsContext
            .PostLikes
            .Include(p => p.User)
            .Where(p => (string.IsNullOrEmpty(query.UserId) || p.UserId == query.UserId) &&
                         (string.IsNullOrEmpty(query.UserName) || p.User!.UserName.StartsWith(query.UserName)) &&
                         (string.IsNullOrEmpty(query.PostId) || p.PostId == query.PostId))
            .OrderEntities(query.SortOrder, query.SortPropertyName)
            .ToPagedListAsync(query.Page, query.PageSize, cancellationToken);

        return postLikes;
    }

    public async Task<PostLike?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var postLike = await _postsContext
            .PostLikes
            .Include(m => m.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return postLike;
    }
}
