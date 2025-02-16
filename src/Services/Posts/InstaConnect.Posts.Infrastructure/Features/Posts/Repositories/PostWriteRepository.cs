using InstaConnect.Posts.Domain.Features.Posts.Abstract;
using InstaConnect.Posts.Domain.Features.Posts.Models.Entitites;

using Microsoft.EntityFrameworkCore;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostWriteRepository : IPostWriteRepository
{
    private readonly PostsContext _postsContext;

    public PostWriteRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var post = await _postsContext
            .Posts
            .Include(f => f.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return post;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = await _postsContext
            .Posts
            .AnyAsync(cancellationToken);

        return any;
    }

    public void Add(Post post)
    {
        _postsContext
            .Posts
            .Add(post);
    }

    public void Update(Post post)
    {
        _postsContext
            .Posts
            .Update(post);
    }

    public void Delete(Post post)
    {
        _postsContext
            .Posts
            .Remove(post);
    }
}
