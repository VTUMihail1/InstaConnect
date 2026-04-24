using InstaConnect.Common.Domain.Features.Mappers.Abstractions;

namespace InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

internal class VerifyForgotPasswordTokenCommandHandler : ICommandHandler<VerifyForgotPasswordTokenCommandRequest>
{
    private readonly IApplicationMapper _mapper;
    private readonly IForgotPasswordTokenCommandService _forgotPasswordTokenService;

    public VerifyForgotPasswordTokenCommandHandler(
        IApplicationMapper mapper,
        IForgotPasswordTokenCommandService forgotPasswordTokenService)
    {
        _mapper = mapper;
        _forgotPasswordTokenService = forgotPasswordTokenService;
    }

    public async Task Handle(VerifyForgotPasswordTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _mapper.Map<VerifyForgotPasswordTokenCommand>(request);
        await _forgotPasswordTokenService.VerifyAsync(serviceRequest, cancellationToken);
    }
}
