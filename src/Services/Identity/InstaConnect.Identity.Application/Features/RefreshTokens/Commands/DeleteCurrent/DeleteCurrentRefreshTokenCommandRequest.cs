namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.DeleteCurrent;

public record DeleteCurrentRefreshTokenCommandRequest(string Id, string Value) : ICommandRequest;
