using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

namespace InstaConnect.ForgotPasswordTokens.Application.Features.ForgotPasswordTokens.Commands.Add;

internal class VerifyForgotPasswordTokenCommandHandler : ICommandHandler<VerifyForgotPasswordTokenCommandRequest, VerifyForgotPasswordTokenCommandResponse>
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
