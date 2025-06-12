using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Repositories;

internal class PostRepository : IPostRepository
{
    private readonly PostsContext _postsContext;

    public PostRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public Task<PostQueryCollection> GetAllAsync(PostQueryParameters query, CancellationToken cancellationToken)
    {

    }

    public async Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var post = await _postsContext
            .Posts
            .Include(f => f.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return post;
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
