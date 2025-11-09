namespace InstaConnect.Identity.Application.Features.Users.Commands.DeleteCurrent;

internal class DeleteCurrentUserCommandHandler : ICommandHandler<DeleteCurrentUserCommandRequest>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public DeleteCurrentUserCommandHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(
        DeleteCurrentUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeleteUserCommand>(request);
        await _userService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
