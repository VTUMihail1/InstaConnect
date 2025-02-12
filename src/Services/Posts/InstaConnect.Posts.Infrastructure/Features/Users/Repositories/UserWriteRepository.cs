using InstaConnect.Posts.Domain.Features.Users.Abstract;
using InstaConnect.Posts.Domain.Features.Users.Models.Entitites;
using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Infrastructure.Features.Users.Repositories;

internal class UserWriteRepository : IUserWriteRepository
{
    private readonly PostsContext _postsContext;

    public UserWriteRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<User?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var user = await _postsContext
            .Users
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return user;
    }

    public void Add(User user)
    {
        _postsContext
            .Users
            .Add(user);
    }

    public void Update(User user)
    {
        _postsContext
            .Users
            .Update(user);
    }

    public void Delete(User user)
    {
        _postsContext
            .Users
            .Remove(user);
    }
}
