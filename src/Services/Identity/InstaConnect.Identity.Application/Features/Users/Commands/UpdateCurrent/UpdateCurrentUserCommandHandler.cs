using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Users.Domain.Features.Users.Abstractions;

namespace InstaConnect.Users.Application.Features.Users.Commands.Update;

public class UpdateCurrentUserCommandHandler : ICommandHandler<UpdateCurrentUserCommandRequest, UpdateCurrentUserCommandResponse>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public UpdateCurrentUserCommandHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task<UpdateCurrentUserCommandResponse> Handle(
        UpdateCurrentUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdateUserCommand>(request);
        var user = await _userService.UpdateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<UpdateCurrentUserCommandResponse>(user);

        return response;
    }
}
