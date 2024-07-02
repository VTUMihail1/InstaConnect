using InstaConnect.Posts.Data.Write.Abstract;
using InstaConnect.Posts.Data.Write.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Write.Repositories;

public class PostCommentRepository : BaseRepository<PostComment>, IPostCommentRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
