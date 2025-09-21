using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Add;

internal class IssueRefreshTokenCommandHandler : ICommandHandler<IssueRefreshTokenCommandRequest, IssueRefreshTokenCommandResponse>
{
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IEmailConfirmationTokenService _emailConfirmationTokenService;

    public IssueRefreshTokenCommandHandler(
        IRefreshTokenService refreshTokenService,
        IApplicationMapper applicationMapper,
        IEmailConfirmationTokenService emailConfirmationTokenService)
    {
        _refreshTokenService = refreshTokenService;
        _applicationMapper = applicationMapper;
        _emailConfirmationTokenService = emailConfirmationTokenService;
    }

    public async Task<IssueRefreshTokenCommandResponse> Handle(IssueRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<IssueRefreshTokenCommand>(request);
        var refreshToken = await _refreshTokenService.IssueAsync(serviceRequest, cancellationToken);

        var tokenServiceRequest = _applicationMapper.Map<AddEmailConfirmationTokenCommand>(refreshToken);
        await _emailConfirmationTokenService.AddAsync(tokenServiceRequest, cancellationToken);

        var response = _applicationMapper.Map<IssueRefreshTokenCommandResponse>(refreshToken);

        return response;
    }
}
