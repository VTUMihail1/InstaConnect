using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Read.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    private readonly PostsContext _postsContext;

    public PostRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
