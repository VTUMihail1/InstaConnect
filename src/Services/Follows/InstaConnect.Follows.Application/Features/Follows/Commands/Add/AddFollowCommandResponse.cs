namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

public record AddFollowCommandResponse(string FollowerId, string FollowingId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
