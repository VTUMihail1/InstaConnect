namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Abstractions;
public interface IPostsClient
{
    Task<PostCommandResponse> AddAsync(AddPostRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddPostRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(AddPostRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeletePostRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeletePostRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeletePostRequest request, CancellationToken cancellationToken);
    Task<PostPaginationQueryResponse> GetAllAsync(GetAllPostsRequest request, CancellationToken cancellationToken);
    Task<PostPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllPostsRequest request, CancellationToken cancellationToken);
    Task<PostQueryResponse> GetByIdAsync(GetPostByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetPostByIdRequest request, CancellationToken cancellationToken);
    Task<PostCommandResponse> UpdateAsync(UpdatePostRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeAsync(UpdatePostRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeUnauthorizedAsync(UpdatePostRequest request, CancellationToken cancellationToken);
}
