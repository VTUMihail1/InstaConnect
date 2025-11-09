namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeService
{
    public Task<PostCommentLikeCollection> GetAllAsync(GetAllPostCommentLikesQuery query, CancellationToken cancellationToken);

    public Task<PostCommentLike> GetByIdAsync(GetPostCommentLikeByIdQuery query, CancellationToken cancellationToken);

    public Task<PostCommentLike> AddAsync(AddPostCommentLikeCommand command, CancellationToken cancellationToken);

    public Task DeleteAsync(DeletePostCommentLikeCommand command, CancellationToken cancellationToken);
}
