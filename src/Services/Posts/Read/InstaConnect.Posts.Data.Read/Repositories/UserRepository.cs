using InstaConnect.Messages.Data.Read.Abstractions;
using InstaConnect.Messages.Data.Read.Models.Entities;
using InstaConnect.Posts.Data.Read;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Messages.Data.Read.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly PostsContext _postsContext;

    public UserRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
