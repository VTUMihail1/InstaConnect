namespace InstaConnect.Follows.Presentation.Features.Follows.Models.Responses;

public record AddFollowApiResponse(string FollowerId, string FollowingId, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt);
