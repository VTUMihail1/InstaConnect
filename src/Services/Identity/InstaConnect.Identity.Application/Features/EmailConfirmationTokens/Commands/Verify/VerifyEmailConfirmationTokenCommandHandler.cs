namespace InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

internal class VerifyEmailConfirmationTokenCommandHandler : ICommandHandler<VerifyEmailConfirmationTokenCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenService _emailConfirmationTokenService;

    public VerifyEmailConfirmationTokenCommandHandler(
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenService emailConfirmationTokenService)
    {
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenService = emailConfirmationTokenService;
    }

    public async Task Handle(VerifyEmailConfirmationTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<VerifyEmailConfirmationTokenCommand>(request);
        await _emailConfirmationTokenService.VerifyAsync(serviceRequest, cancellationToken);
    }
}
