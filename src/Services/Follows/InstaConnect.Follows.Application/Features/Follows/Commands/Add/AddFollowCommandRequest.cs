namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

public record AddFollowCommandRequest(string FollowerId, string FollowingId) : ICommandRequest<AddFollowCommandResponse>;
