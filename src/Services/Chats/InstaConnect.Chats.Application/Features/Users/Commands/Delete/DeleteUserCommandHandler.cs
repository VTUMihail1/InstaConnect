namespace InstaConnect.Chats.Application.Features.Users.Commands.Delete;

internal class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommandRequest>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public DeleteUserCommandHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(
        DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeleteUserCommand>(request);
        await _userService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
