namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Abstractions;
public interface IFollowsClient
{
    Task<FollowCommandResponse> AddAsync(AddFollowRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddFollowRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(AddFollowRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteFollowRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeleteFollowRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeleteFollowRequest request, CancellationToken cancellationToken);
    Task<FollowPaginationQueryResponse> GetAllAsync(GetAllFollowsRequest request, CancellationToken cancellationToken);
    Task<FollowPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllFollowsRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(CancellationToken cancellationToken);
    Task<FollowQueryResponse> GetByIdAsync(GetFollowByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetFollowByIdRequest request, CancellationToken cancellationToken);
}
