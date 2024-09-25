using InstaConnect.Posts.Data.Features.Posts.Models.Entitites;

namespace InstaConnect.Posts.Data.Features.Posts.Abstract;
public interface IPostWriteRepository
{
    void Add(Post post);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(Post post);
    Task<Post?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(Post post);
}
