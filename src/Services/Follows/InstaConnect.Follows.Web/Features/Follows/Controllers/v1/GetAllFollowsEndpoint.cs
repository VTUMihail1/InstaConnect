using InstaConnect.Follows.Business.Features.Follows.Queries.GetAllFollows;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using FastEndpoints;

namespace InstaConnect.Follows.Web.Features.Follows.Controllers.v1;

public class GetAllFollowsEndpoint : Endpoint<GetAllFollowsRequest, FollowPaginationQueryResponse>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;

    public GetAllFollowsEndpoint(IInstaConnectMapper instaConnectMapper, IInstaConnectSender instaConnectSender)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
    }

    public override void Configure()
    {
        Get("api/v{version:apiVersion}/follows");
        AllowAnonymous();
        Options(x => x.RequireRateLimiting(AppPolicies.RateLimiterPolicy));
    }

    public override async Task HandleAsync(GetAllFollowsRequest req, CancellationToken ct)
    {
        var queryRequest = _instaConnectMapper.Map<GetAllFollowsQuery>(req);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, ct);
        var response = _instaConnectMapper.Map<FollowPaginationQueryResponse>(queryResponse);

        await SendOkAsync(response, ct);
    }
}

