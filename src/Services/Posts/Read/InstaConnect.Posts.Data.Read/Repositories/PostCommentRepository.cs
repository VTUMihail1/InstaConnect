using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Read.Repositories;

public class PostCommentRepository : BaseRepository<PostComment>, IPostCommentRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
