namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostService
{
    public Task<PostCollection> GetAllAsync(GetAllPostsQuery query, CancellationToken cancellationToken);

    public Task<Post> GetByIdAsync(GetPostByIdQuery query, CancellationToken cancellationToken);

    public Task<Post> AddAsync(AddPostCommand command, CancellationToken cancellationToken);

    public Task<Post> UpdateAsync(UpdatePostCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostCommand command, CancellationToken cancellationToken);
}
