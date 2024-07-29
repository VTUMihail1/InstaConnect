using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Features.Posts.Repositories;

internal class PostReadRepository : BaseReadRepository<Post>, IPostReadRepository
{
    public PostReadRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
