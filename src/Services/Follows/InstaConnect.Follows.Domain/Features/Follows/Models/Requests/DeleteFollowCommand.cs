namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record DeleteFollowCommand(
    string FollowerId,
    string FollowingId);
