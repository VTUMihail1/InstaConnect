namespace InstaConnect.Identity.Application.Features.RefreshTokens.Commands.Delete;

public record DeleteCurrentRefreshTokenCommandRequest(string Id, string Value) : ICommandRequest;
