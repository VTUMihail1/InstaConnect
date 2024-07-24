using InstaConnect.Posts.Read.Data;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Write.Data.Repositories;

internal class PostCommentWriteRepository : BaseWriteRepository<PostComment>, IPostCommentWriteRepository
{
    public PostCommentWriteRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
