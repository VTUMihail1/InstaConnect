using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Posts.Data.Features.Users.Models.Entitites;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Features.Users.Repositories;

internal class UserWriteRepository : BaseWriteRepository<User>, IUserWriteRepository
{
    public UserWriteRepository(PostsContext postsContext) : base(postsContext)
    {
    }
}
