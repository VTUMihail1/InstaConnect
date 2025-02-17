using InstaConnect.Posts.Domain.Features.Posts.Models.Entities;

namespace InstaConnect.Posts.Domain.Features.Posts.Abstractions;
public interface IPostWriteRepository
{
    void Add(Post post);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(Post post);
    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(Post post);
}
