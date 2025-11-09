namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;

internal class AddEmailConfirmationTokenCommandHandler : ICommandHandler<AddEmailConfirmationTokenCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenService _emailConfirmationTokenService;

    public AddEmailConfirmationTokenCommandHandler(
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenService emailConfirmationTokenService)
    {
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenService = emailConfirmationTokenService;
    }

    public async Task Handle(AddEmailConfirmationTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddEmailConfirmationTokenCommand>(request);
        await _emailConfirmationTokenService.AddAsync(serviceRequest, cancellationToken);
    }
}
