using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Users.Application.Features.Users.Commands.Add;
using InstaConnect.Users.Domain.Features.Users.Abstractions;
using InstaConnect.Users.Domain.Features.Users.Models.Requests;

namespace InstaConnect.Users.Application.Features.Users.Commands.Delete;

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
