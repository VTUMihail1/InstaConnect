using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Users.Application.Features.Users.Commands.Add;

internal class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommandRequest>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public UpdateUserCommandHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdateUserCommand>(request);
        await _userService.UpdateAsync(serviceRequest, cancellationToken);
    }
}
