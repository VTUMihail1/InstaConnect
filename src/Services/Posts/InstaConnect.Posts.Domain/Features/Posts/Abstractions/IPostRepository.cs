using InstaConnect.Posts.Domain.Features.Posts.Models;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;

public interface IPostRepository
{
    Task<PostQueryCollection> GetAllAsync(PostQueryParameters query, CancellationToken cancellationToken);

    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);

    void Add(Post post);

    void Update(Post post);

    void Delete(Post post);
}
