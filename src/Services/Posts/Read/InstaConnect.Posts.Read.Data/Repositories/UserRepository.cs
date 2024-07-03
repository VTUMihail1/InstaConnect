using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Posts.Read.Data.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Read.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly PostsContext _postsContext;

    public UserRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
