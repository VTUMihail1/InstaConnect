using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Posts.Application.Features.Posts.Commands.Update;
using InstaConnect.Posts.Domain.Features.Posts.Abstractions;

namespace InstaConnect.Users.Application.Features.Users.Commands.Add;

internal class UpdateUserCommandHandler : ICommandHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
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

    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdateUserCommand>(request);
        var user = await _userService.UpdateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<UpdateUserCommandResponse>(user);

        return response;
    }
}
