namespace InstaConnect.Posts.Domain.Features.PostComments.Abstractions;

public interface IPostCommentQueryService
{
    public Task<PostCommentCollectionResponse> GetAllAsync(GetAllPostCommentsQuery query, CancellationToken cancellationToken);

    public Task<PostCommentCollectionResponse> GetAllForUserAsync(GetAllPostCommentsForUserQuery query, CancellationToken cancellationToken);

    public Task<PostCommentResponse> GetByIdAsync(GetPostCommentByIdQuery query, CancellationToken cancellationToken);
}
