namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

internal class AddFollowCommandHandler : ICommandHandler<AddFollowCommandRequest, AddFollowCommandResponse>
{
    private readonly IFollowService _followService;
    private readonly IApplicationMapper _applicationMapper;

    public AddFollowCommandHandler(
        IFollowService followService,
        IApplicationMapper applicationMapper)
    {
        _followService = followService;
        _applicationMapper = applicationMapper;
    }

    public async Task<AddFollowCommandResponse> Handle(AddFollowCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddFollowCommand>(request);
        var follow = await _followService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddFollowCommandResponse>(follow);

        return response;
    }
}
