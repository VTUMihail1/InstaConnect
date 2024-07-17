using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Posts.Write.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Write.Data.Repositories;

public class PostRepository : BaseReadRepository<Post>, IPostRepository
{
    private readonly PostsContext _postsContext;

    public PostRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
