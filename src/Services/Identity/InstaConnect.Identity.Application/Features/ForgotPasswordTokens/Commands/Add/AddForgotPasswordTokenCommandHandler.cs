using InstaConnect.Identity.Domain.Features.ForgotPasswordTokens.Models.Requests;

namespace InstaConnect.ForgotPasswordTokens.Application.Features.ForgotPasswordTokens.Commands.Add;

internal class AddForgotPasswordTokenCommandHandler : ICommandHandler<AddForgotPasswordTokenCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IForgotPasswordTokenService _forgotPasswordTokenService;

    public AddForgotPasswordTokenCommandHandler(
        IApplicationMapper applicationMapper,
        IForgotPasswordTokenService forgotPasswordTokenService)
    {
        _applicationMapper = applicationMapper;
        _forgotPasswordTokenService = forgotPasswordTokenService;
    }

    public async Task Handle(AddForgotPasswordTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddForgotPasswordTokenCommand>(request);
        await _forgotPasswordTokenService.AddAsync(serviceRequest, cancellationToken);
    }
}
