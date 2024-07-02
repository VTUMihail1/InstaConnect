using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Entities;
using InstaConnect.Shared.Data.Repositories;

namespace InstaConnect.Posts.Data.Read.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly PostsContext _postsContext;

    public UserRepository(PostsContext postsContext) : base(postsContext)
    {
        _postsContext = postsContext;
    }
}
