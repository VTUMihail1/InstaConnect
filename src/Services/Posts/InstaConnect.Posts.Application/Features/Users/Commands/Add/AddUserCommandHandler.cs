using InstaConnect.Posts.Application.Features.Posts.Commands.Add;

namespace InstaConnect.Users.Application.Features.Users.Commands.Add;

internal class AddUserCommandHandler : ICommandHandler<AddUserCommandRequest>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public AddUserCommandHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddUserCommand>(request);
        await _userService.AddAsync(serviceRequest, cancellationToken);
    }
}
