using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Repositories
{
    public class PostCommentRepository : BaseRepository<PostComment>, IPostCommentRepository
    {
        private readonly PostsContext _postsContext;

        public PostCommentRepository(PostsContext postsContext) : base(postsContext)
        {
            _postsContext = postsContext;
        }
    }
}
