using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Features.PostComments.Repositories;

internal class PostCommentWriteRepository : BaseWriteRepository<PostComment>, IPostCommentWriteRepository
{
    public PostCommentWriteRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
