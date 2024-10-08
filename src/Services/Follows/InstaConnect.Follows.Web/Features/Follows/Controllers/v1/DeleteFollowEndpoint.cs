using InstaConnect.Follows.Business.Features.Follows.Commands.DeleteFollow;
using InstaConnect.Follows.Web.Features.Follows.Models.Requests;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using FastEndpoints;

namespace InstaConnect.Follows.Web.Features.Follows.Controllers.v1;

public class DeleteFollowEndpoint : Endpoint<DeleteFollowRequest>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;
    private readonly ICurrentUserContext _currentUserContext;

    public DeleteFollowEndpoint(IInstaConnectMapper instaConnectMapper, IInstaConnectSender instaConnectSender, ICurrentUserContext currentUserContext)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
        _currentUserContext = currentUserContext;
    }

    public override void Configure()
    {
        Delete("api/v{version:apiVersion}/follows");
        Version(1);
        Options(x => x.RequireRateLimiting(AppPolicies.RateLimiterPolicy));
    }

    public override async Task HandleAsync(DeleteFollowRequest req, CancellationToken ct)
    {
        var currentUser = _currentUserContext.GetCurrentUser();
        var commandRequest = _instaConnectMapper.Map<DeleteFollowCommand>((currentUser, req));
        await _instaConnectSender.SendAsync(commandRequest, ct);

        await SendNoContentAsync(ct);
    }
}

