namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostLikes.Abstractions;
public interface IPostLikesClient
{
    Task<PostLikeCommandResponse> AddAsync(AddPostLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddPostLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(AddPostLikeRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeletePostLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeletePostLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeletePostLikeRequest request, CancellationToken cancellationToken);
    Task<PostLikePaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<PostLikePaginationQueryResponse> GetAllAsync(GetAllPostLikesRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllPostLikesRequest request, CancellationToken cancellationToken);
    Task<PostLikeQueryResponse> GetByIdAsync(GetPostLikeByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetPostLikeByIdRequest request, CancellationToken cancellationToken);
}