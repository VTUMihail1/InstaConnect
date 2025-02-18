namespace InstaConnect.Posts.Infrastructure.Features.PostComments.Repositories;

internal class PostCommentWriteRepository : IPostCommentWriteRepository
{
    private readonly PostsContext _postsContext;

    public PostCommentWriteRepository(PostsContext postsContext)
    {
        _postsContext = postsContext;
    }

    public async Task<PostComment?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var postComment = await _postsContext
            .PostComments
            .Include(f => f.User)
            .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

        return postComment;
    }

    public async Task<bool> AnyAsync(CancellationToken cancellationToken)
    {
        var any = await _postsContext
            .PostComments
            .AnyAsync(cancellationToken);

        return any;
    }

    public void Add(PostComment postComment)
    {
        _postsContext
            .PostComments
            .Add(postComment);
    }

    public void Update(PostComment postComment)
    {
        _postsContext
            .PostComments
            .Update(postComment);
    }

    public void Delete(PostComment postComment)
    {
        _postsContext
            .PostComments
            .Remove(postComment);
    }
}
