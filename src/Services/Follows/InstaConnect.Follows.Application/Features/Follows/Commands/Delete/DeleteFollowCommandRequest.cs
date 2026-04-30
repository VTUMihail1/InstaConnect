namespace InstaConnect.Follows.Application.Features.Follows.Commands.Delete;

public record DeleteFollowCommandRequest(string FollowerId, string FollowingId) : ICommandRequest;
