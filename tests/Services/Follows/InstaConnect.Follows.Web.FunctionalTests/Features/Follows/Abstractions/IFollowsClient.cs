using System.Net;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;

namespace InstaConnect.Follows.Web.FunctionalTests.Features.Follows.Abstractions;
public interface IFollowsClient
{
    Task<HttpStatusCode> AddStatusCodeAsync(AddFollowRequest request, Dictionary<string, object>? jwtConfig = null);
    Task<FollowCommandResponse> AddAsync(AddFollowRequest request, Dictionary<string, object>? jwtConfig = null);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeleteFollowRequest request, Dictionary<string, object>? jwtConfig = null);
    Task DeleteAsync(DeleteFollowRequest request, Dictionary<string, object>? jwtConfig = null);
    Task<FollowPaginationQueryResponse> GetAllAsync(GetAllFollowsRequest? request = null);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllFollowsRequest? request = null);
    Task<FollowQueryResponse> GetByIdAsync(GetFollowByIdRequest request);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetFollowByIdRequest request);
}
