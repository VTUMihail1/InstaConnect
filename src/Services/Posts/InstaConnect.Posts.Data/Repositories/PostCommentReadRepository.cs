using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Read.Data.Repositories;

internal class PostCommentReadRepository : BaseReadRepository<PostComment>, IPostCommentReadRepository
{
    public PostCommentReadRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
