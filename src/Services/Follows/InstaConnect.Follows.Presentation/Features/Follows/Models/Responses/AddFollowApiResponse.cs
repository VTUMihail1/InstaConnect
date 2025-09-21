namespace InstaConnect.Follows.Application.Features.Follows.Commands.Add;

public record AddFollowApiResponse(string FollowerId, string FollowingId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
