namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

public record AddFollowCommandRequest(UserIdPayload FollowerId, UserIdPayload FollowingId) : ICommandRequest<AddFollowCommandResponse>;
