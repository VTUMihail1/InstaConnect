namespace InstaConnect.Posts.Domain.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikeQueryService
{
    public Task<PostCommentLikeCollectionResponse> GetAllAsync(GetAllPostCommentLikesQuery query, CancellationToken cancellationToken);

    public Task<PostCommentLikeCollectionResponse> GetAllForUserAsync(GetAllPostCommentLikesForUserQuery query, CancellationToken cancellationToken);

    public Task<PostCommentLikeResponse> GetByIdAsync(GetPostCommentLikeByIdQuery query, CancellationToken cancellationToken);
}
