using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Repositories
{
    public class PostCommentLikeRepository : BaseRepository<PostCommentLike>, IPostCommentLikeRepository
    {
        private readonly PostsContext _postsContext;

        public PostCommentLikeRepository(PostsContext postsContext) : base(postsContext)
        {
            _postsContext = postsContext;
        }
    }
}
