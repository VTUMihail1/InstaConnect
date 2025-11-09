namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

internal class VerifyForgotPasswordTokenCommandHandler : ICommandHandler<VerifyForgotPasswordTokenCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IForgotPasswordTokenService _forgotPasswordTokenService;

    public VerifyForgotPasswordTokenCommandHandler(
        IApplicationMapper applicationMapper,
        IForgotPasswordTokenService forgotPasswordTokenService)
    {
        _applicationMapper = applicationMapper;
        _forgotPasswordTokenService = forgotPasswordTokenService;
    }

    public async Task Handle(VerifyForgotPasswordTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<VerifyForgotPasswordTokenCommand>(request);
        await _forgotPasswordTokenService.VerifyAsync(serviceRequest, cancellationToken);
    }
}
