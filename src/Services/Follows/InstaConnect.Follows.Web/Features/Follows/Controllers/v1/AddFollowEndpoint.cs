using InstaConnect.Follows.Business.Features.Follows.Commands.AddFollow;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Follows.Web.Features.Follows.Models.Responses;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using FastEndpoints;

namespace InstaConnect.Follows.Web.Features.Follows.Controllers.v1;

public class AddFollowEndpoint : Endpoint<AddFollowRequest, FollowCommandResponse>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly ICurrentUserContext _currentUserContext;

    public AddFollowEndpoint(IInstaConnectMapper instaConnectMapper, IInstaConnectSender instaConnectSender, ICurrentUserContext currentUserContext)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
        _currentUserContext = currentUserContext;
    }

    public override void Configure()
    {
        Post("api/v{version:apiVersion}/follows");
        Version(1);
        Options(x => x.RequireRateLimiting(AppPolicies.RateLimiterPolicy));
    }

    public override async Task HandleAsync(AddFollowRequest req, CancellationToken ct)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<AddFollowCommand>((currentUser, req));
        var commandResponse = await _instaConnectSender.SendAsync(commandRequest, ct);
        var response = _instaConnectMapper.Map<FollowCommandResponse>(commandResponse);

        await SendNoContentAsync(ct);
    }
}

