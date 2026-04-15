namespace InstaConnect.Posts.Domain.Features.PostLikes.Abstractions;

public interface IPostLikeQueryService
{
    public Task<PostLikeCollectionResponse> GetAllAsync(GetAllPostLikesQuery query, CancellationToken cancellationToken);

    public Task<PostLikeCollectionResponse> GetAllForUserAsync(GetAllPostLikesForUserQuery query, CancellationToken cancellationToken);

    public Task<PostLikeResponse> GetByIdAsync(GetPostLikeByIdQuery query, CancellationToken cancellationToken);
}
