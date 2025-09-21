using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Posts.Application.Features.Posts.Commands.Add;
using InstaConnect.Users.Domain.Features.Users.Abstractions;

namespace InstaConnect.Users.Application.Features.Users.Commands.Add;

internal class AddUserCommandHandler : ICommandHandler<AddUserCommandRequest, AddUserCommandResponse>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenService _emailConfirmationTokenService;

    public AddUserCommandHandler(
        IUserService userService,
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenService emailConfirmationTokenService)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenService = emailConfirmationTokenService;
    }

    public async Task<AddUserCommandResponse> Handle(AddUserCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddUserCommand>(request);
        var user = await _userService.AddAsync(serviceRequest, cancellationToken);

        var tokenServiceRequest = _applicationMapper.Map<AddEmailConfirmationTokenCommand>(user);
        await _emailConfirmationTokenService.AddAsync(tokenServiceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddUserCommandResponse>(user);

        return response;
    }
}
