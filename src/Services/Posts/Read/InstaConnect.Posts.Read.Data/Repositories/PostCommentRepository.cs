using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Read.Data.Repositories;

public class PostCommentRepository : BaseRepository<PostComment>, IPostCommentRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
