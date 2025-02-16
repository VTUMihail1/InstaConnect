using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Domain.Features.PostComments.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Repositories;

internal class PostCommentReadRepository : IPostCommentReadRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentReadRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<PaginationList<PostComment>> GetAllAsync(PostCommentCollectionReadQuery query, CancellationToken cancellationToken)
    {
        var postComments = await _postsContext
            .PostComments
            .Include(p => p.User)
            .Where(p => (string.IsNullOrEmpty(query.UserId) || p.UserId == query.UserId) &&
                         (string.IsNullOrEmpty(query.UserName) || p.User!.UserName.StartsWith(query.UserName)) &&
                         (string.IsNullOrEmpty(query.PostId) || p.PostId == query.PostId))
            .OrderEntities(query.SortOrder, query.SortPropertyName)
            .ToPagedListAsync(query.Page, query.PageSize, cancellationToken);

        return postComments;
    }

    public async Task<PostComment?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var postComment = await _postsContext
            .PostComments
            .Include(m => m.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return postComment;
    }
}
