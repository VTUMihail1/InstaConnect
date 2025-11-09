namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;

internal class DeleteCurrentRefreshTokenCommandHandler : ICommandHandler<DeleteCurrentRefreshTokenCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IRefreshTokenService _refreshTokenService;

    public DeleteCurrentRefreshTokenCommandHandler(
        IApplicationMapper applicationMapper,
        IRefreshTokenService refreshTokenService)
    {
        _applicationMapper = applicationMapper;
        _refreshTokenService = refreshTokenService;
    }

    public async Task Handle(
        DeleteCurrentRefreshTokenCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeleteRefreshTokenCommand>(request);
        await _refreshTokenService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
