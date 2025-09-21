using InstaConnect.Identity.Domain.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Abstractions;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

namespace InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Add;

internal class RotateRefreshTokenCommandHandler : ICommandHandler<RotateRefreshTokenCommandRequest, RotateRefreshTokenCommandResponse>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IRefreshTokenService _refreshTokenService;

    public RotateRefreshTokenCommandHandler(
        IApplicationMapper applicationMapper,
        IRefreshTokenService refreshTokenService)
    {
        _applicationMapper = applicationMapper;
        _refreshTokenService = refreshTokenService;
    }

    public async Task<RotateRefreshTokenCommandResponse> Handle(RotateRefreshTokenCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<RotateRefreshTokenCommand>(request);
        var refreshToken = await _refreshTokenService.RotateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<RotateRefreshTokenCommandResponse>(refreshToken);

        return response;
    }
}
