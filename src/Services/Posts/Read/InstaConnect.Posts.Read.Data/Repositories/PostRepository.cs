using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Read.Data.Repositories;

public class PostRepository : BaseRepository<Post>, IPostRepository
{
    private readonly PostsContext _postsContext;

    public PostRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
