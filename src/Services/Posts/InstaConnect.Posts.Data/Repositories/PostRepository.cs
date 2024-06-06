using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    private readonly PostsContext _postsContext;

    public PostRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
