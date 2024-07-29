using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Features.Posts.Repositories;

internal class PostWriteRepository : BaseWriteRepository<Post>, IPostWriteRepository
{
    public PostWriteRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
