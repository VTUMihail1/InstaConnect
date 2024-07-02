using InstaConnect.Posts.Data.Write.Abstract;
using InstaConnect.Posts.Data.Write.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Write.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    private readonly PostsContext _postsContext;

    public PostRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
