namespace InstaConnect.Posts.Application.Features.Users.Commands.Add;

internal class AddUserCommandHandler : ICommandHandler<AddUserCommandRequest, AddUserCommandResponse>
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

    public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddUserCommand>(request);
        var user = await _userService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddUserCommandResponse>(user);

        return response;
    }
}
