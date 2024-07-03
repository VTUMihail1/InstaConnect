using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Posts.Write.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Write.Data.Repositories;

public class PostCommentRepository : BaseRepository<PostComment>, IPostCommentRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
