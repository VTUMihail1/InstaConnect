namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;

public record DeleteCurrentRefreshTokenCommandRequest(RefreshTokenIdPayload Id) : ICommandRequest;
