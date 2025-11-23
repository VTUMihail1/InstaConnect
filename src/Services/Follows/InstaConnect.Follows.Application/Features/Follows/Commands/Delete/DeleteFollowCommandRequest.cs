namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

public record DeleteFollowCommandRequest(FollowIdPayload Id) : ICommandRequest;
