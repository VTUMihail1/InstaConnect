using InstaConnect.Posts.Read.Data;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Write.Data.Repositories;

internal class PostWriteRepository : BaseWriteRepository<Post>, IPostWriteRepository
{
    public PostWriteRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
