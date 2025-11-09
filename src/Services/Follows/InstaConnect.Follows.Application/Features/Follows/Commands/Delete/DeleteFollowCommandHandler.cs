namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

internal class DeleteFollowCommandHandler : ICommandHandler<DeleteFollowCommandRequest>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;

    public DeleteFollowCommandHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(
        DeleteFollowCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeleteFollowCommand>(request);
        await _followService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
