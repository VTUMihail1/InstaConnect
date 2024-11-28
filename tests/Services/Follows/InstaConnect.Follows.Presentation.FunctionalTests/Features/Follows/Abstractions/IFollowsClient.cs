using System.Net;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Requests;
using InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;
using InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Models;

namespace InstaConnect.Follows.Presentation.FunctionalTests.Features.Follows.Abstractions;
public interface IFollowsClient
{
    Task<HttpStatusCode> AddStatusCodeAsync(
        AddFollowClientRequest request,
        CancellationToken cancellationToken);

    Task<FollowCommandResponse> AddAsync(
        AddFollowClientRequest request,
        CancellationToken cancellationToken);

    Task<HttpStatusCode> DeleteStatusCodeAsync(
        DeleteFollowClientRequest request,
        CancellationToken cancellationToken);

    Task DeleteAsync(
        DeleteFollowClientRequest request,
        CancellationToken cancellationToken);

    Task<FollowPaginationQueryResponse> GetAllAsync(
        GetAllFollowsClientRequest request,
        CancellationToken cancellationToken);

    Task<HttpStatusCode> GetAllStatusCodeAsync(
        GetAllFollowsClientRequest request,
        CancellationToken cancellationToken);

    Task<FollowQueryResponse> GetByIdAsync(
        GetFollowByIdClientRequest request,
        CancellationToken cancellationToken);

    Task<HttpStatusCode> GetByIdStatusCodeAsync(
        GetFollowByIdClientRequest request,
        CancellationToken cancellationToken);

}
