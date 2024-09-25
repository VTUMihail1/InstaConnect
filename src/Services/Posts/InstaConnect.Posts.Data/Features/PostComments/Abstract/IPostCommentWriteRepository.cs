using InstaConnect.Posts.Data.Features.PostComments.Models.Entitites;

namespace InstaConnect.Posts.Data.Features.PostComments.Abstract;
public interface IPostCommentWriteRepository
{
    void Add(PostComment postComment);
    Task<bool> AnyAsync(CancellationToken cancellationToken);
    void Delete(PostComment postComment);
    Task<PostComment?> GetByIdAsync(string id, CancellationToken cancellationToken);
    void Update(PostComment postComment);
}
