namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.Posts.Abstractions;
public interface IPostsClient
{
    Task<PostCommandResponse> AddAsync(AddPostApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddPostApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(AddPostApiRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeletePostApiRequest request, CancellationToken cancellationToken);
    Task<PostPaginationQueryResponse> GetAllAsync(GetAllPostsApiRequest request, CancellationToken cancellationToken);
    Task<PostPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllPostsApiRequest request, CancellationToken cancellationToken);
    Task<PostQueryResponse> GetByIdAsync(GetPostByIdApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetPostByIdApiRequest request, CancellationToken cancellationToken);
    Task<PostCommandResponse> UpdateAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeUnauthorizedAsync(UpdatePostApiRequest request, CancellationToken cancellationToken);
}
