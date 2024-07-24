using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Read.Data.Repositories;

internal class PostReadRepository : BaseReadRepository<Post>, IPostReadRepository
{
    public PostReadRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
