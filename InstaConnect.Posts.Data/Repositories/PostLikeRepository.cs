using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Repositories
{
    public class PostLikeRepository : BaseRepository<PostLike>, IPostLikeRepository
    {
        private readonly PostsContext _postsContext;

        public PostLikeRepository(PostsContext postsContext) : base(postsContext)
        {
            _postsContext = postsContext;
        }
    }
}
