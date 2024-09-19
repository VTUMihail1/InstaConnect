using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Data.Features.PostComments.Repositories;

internal class PostCommentReadRepository : BaseReadRepository<PostComment>, IPostCommentReadRepository
{
    public PostCommentReadRepository(PostsContext postsContext) : base(postsContext)
    {
    }

    protected override IQueryable<PostComment> IncludeProperties(IQueryable<PostComment> queryable)
    {
        return queryable
            .Include(p => p.User);
    }
}
