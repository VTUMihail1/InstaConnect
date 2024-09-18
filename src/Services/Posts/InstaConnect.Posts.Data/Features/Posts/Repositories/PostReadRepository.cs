using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Features.Posts.Repositories;

internal class PostReadRepository : BaseReadRepository<Post>, IPostReadRepository
{
    public PostReadRepository(PostsContext postsContext) : base(postsContext)
    {
    }

    protected override IQueryable<Post> IncludeProperties(IQueryable<Post> queryable)
    {
        return queryable
            .Include(p => p.User);
    }
}
