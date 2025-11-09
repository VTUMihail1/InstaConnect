namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;
public interface IPostLikeService
{
    public Task<PostLikeCollection> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken);

    public Task<PostLike> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken);

    public Task<PostLike> AddAsync(AddPostLikeCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostLikeCommand command, CancellationToken cancellationToken);
}
