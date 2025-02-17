using InstaConnect.Posts.Domain.Features.Posts.Models.Filters;
using InstaConnect.Shared.Domain.Models.Pagination;
using InstaConnect.Shared.Infrastructure.Extensions;

using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostReadRepository : IPostReadRepository
{
    private readonly PostsContext _postsContext;

    public PostReadRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<PaginationList<Post>> GetAllAsync(PostCollectionReadQuery query, CancellationToken cancellationToken)
    {
        var posts = await _postsContext
            .Posts
            .Include(p => p.User)
            .Where(p => (string.IsNullOrEmpty(query.UserId) || p.UserId == query.UserId) &&
                         (string.IsNullOrEmpty(query.UserName) || p.User!.UserName.StartsWith(query.UserName)) &&
                         (string.IsNullOrEmpty(query.Title) || p.Title.StartsWith(query.Title)))
            .OrderEntities(query.SortOrder, query.SortPropertyName)
            .ToPagedListAsync(query.Page, query.PageSize, cancellationToken);

        return posts;
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
