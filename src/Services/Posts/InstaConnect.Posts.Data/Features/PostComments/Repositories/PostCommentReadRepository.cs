using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Features.PostComments.Repositories;

internal class PostCommentReadRepository : BaseReadRepository<PostComment>, IPostCommentReadRepository
{
    public PostCommentReadRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
