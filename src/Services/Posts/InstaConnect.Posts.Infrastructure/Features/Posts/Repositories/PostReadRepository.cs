using System.Drawing.Printing;
using System.Linq;

using InstaConnect.Common.Domain.Models.Pagination;
using InstaConnect.Common.Infrastructure.Extensions;
using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;
using InstaConnect.Posts.Domain.Features.Posts.Models.Responses;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostReadRepository : IPostReadRepository
{
    private readonly PostsContext _postsContext;

    public PostReadRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<PostCollection> GetAllAsync(GetAllPostsRequest query, CancellationToken cancellationToken)
    {
        var queryable = _postsContext
            .Posts
            .Include(p => p.User)
            .Where(p => (string.IsNullOrEmpty(query.Filter.UserId) || p.UserId == query.Filter.UserId) &&
                         (string.IsNullOrEmpty(query.Filter.UserName) || p.User!.UserName.StartsWith(query.Filter.UserName)) &&
                         (string.IsNullOrEmpty(query.Filter.Title) || p.Title.StartsWith(query.Filter.Title)));

        var totalCount = await queryable.CountAsync(cancellationToken);
        var items = await queryable
            .Skip((query.Pagination.Page - 1) * query.Pagination.PageSize)
            .Take(query.Pagination.PageSize)
            .ToListAsync(cancellationToken);

        return new PostQueryCollection(items, query.Pagination.Page, query.Pagination.PageSize, totalCount);
    }

    public async Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var post = await _postsContext
            .Posts
            .Include(m => m.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return post;
    }
}
