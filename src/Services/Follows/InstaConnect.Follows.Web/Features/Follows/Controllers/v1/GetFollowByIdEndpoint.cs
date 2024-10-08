using InstaConnect.Follows.Business.Features.Follows.Queries.GetFollowById;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using FastEndpoints;

namespace InstaConnect.Follows.Web.Features.Follows.Controllers.v1;

public class GetFollowByIdEndpoint : Endpoint<GetFollowByIdRequest, FollowQueryResponse>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;

    public GetFollowByIdEndpoint(IInstaConnectMapper instaConnectMapper, IInstaConnectSender instaConnectSender)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
    }

    public override void Configure()
    {
        Get("api/v{version:apiVersion}/follows/{id}");
        AllowAnonymous();
        Options(x => x.RequireRateLimiting(AppPolicies.RateLimiterPolicy));
    }

    public override async Task HandleAsync(GetFollowByIdRequest req, CancellationToken ct)
    {
        var queryRequest = _instaConnectMapper.Map<GetFollowByIdQuery>(req);
        var queryResponse = await _instaConnectSender.SendAsync(queryRequest, ct);
        var response = _instaConnectMapper.Map<FollowQueryResponse>(queryResponse);

        await SendOkAsync(response, ct);
    }
}

