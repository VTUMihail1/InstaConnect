namespace InstaConnect.Follows.Domain.Features.Follows.Models.Requests;

public record AddFollowCommand(string FollowerId, string FollowingId);
