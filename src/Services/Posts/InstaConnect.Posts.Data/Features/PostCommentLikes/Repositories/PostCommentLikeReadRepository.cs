using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Filters;
using InstaConnect.Shared.Data.Extensions;
using InstaConnect.Shared.Data.Models.Pagination;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Features.PostCommentLikes.Repositories;

internal class PostCommentLikeReadRepository : IPostCommentLikeReadRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentLikeReadRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<PaginationList<PostCommentLike>> GetAllAsync(PostCommentLikeCollectionReadQuery query, CancellationToken cancellationToken)
    {
        var postCommentLikes = await _postsContext
            .PostCommentLikes
            .Include(p => p.User)
            .Where(p => (string.IsNullOrEmpty(query.UserId) || p.UserId == query.UserId) &&
                         (string.IsNullOrEmpty(query.UserName) || p.User!.UserName.StartsWith(query.UserName)) &&
                         (string.IsNullOrEmpty(query.PostCommentId) || p.PostCommentId == query.PostCommentId))
            .OrderEntities(query.SortOrder, query.SortPropertyName)
            .ToPagedListAsync(query.Page, query.PageSize, cancellationToken);

        return postCommentLikes;
    }

    public async Task<PostCommentLike?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var postCommentLike = await _postsContext
            .PostCommentLikes
            .Include(m => m.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return postCommentLike;
    }
}
